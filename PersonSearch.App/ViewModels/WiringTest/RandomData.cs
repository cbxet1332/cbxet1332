using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PersonSearch.App.ViewModels.Base;
using PersonSearch.Data;
using PersonSearch.Domain;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class RandomData : DisposableVM
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IApplicationDbContextFactory _contextFactory;
        private readonly Random _random;
        private readonly BehaviorSubject<RandomDataItem>[] _randomDataItems;
        private readonly int _personCount;

        public RandomData(IRepository<Person> personRepository, IApplicationDbContextFactory contextFactory)
        {
            _personRepository = personRepository;
            _contextFactory = contextFactory;

            var initialData = new RandomDataItem { Person = "Waiting..." };
            _randomDataItems = new []
            {
                new BehaviorSubject<RandomDataItem>(initialData), 
                new BehaviorSubject<RandomDataItem>(initialData)
            };

            _random = new Random();

            using var context = contextFactory.Create(QueryTrackingBehavior.NoTracking);
                _personCount = personRepository.Count(context);

            AddProperty<IEnumerable<RandomDataItem>>("Data")
                .DisposeWith(this)
                .SubscribeTo(Observable.CombineLatest(_randomDataItems[0], _randomDataItems[1]));

            Observable.Interval(TimeSpan.FromSeconds(3))
                .Subscribe(_ => UpdateRandomData(0))
                .DisposeWith(this);

            Observable.Interval(TimeSpan.FromSeconds(5))
                .Subscribe(_ => UpdateRandomData(1))
                .DisposeWith(this);
        }

        private void UpdateRandomData(int index)
        {
            var randomPersonIndex = _random.Next(0, _personCount - 1);
            using var context = _contextFactory.Create(QueryTrackingBehavior.NoTracking);
                _randomDataItems[index].OnNext(_personRepository
                    .SkipTake(randomPersonIndex, 1, context, person => person.Group)
                    .ToList()
                    .Select(person => new RandomDataItem
                    {
                        Index = index,
                        Id = person.Id,
                        Person = $"{person.Forenames} {person.Surname}",
                        Group = person.Group.Name
                    })
                    .First());
        }
    }

    public class RandomDataItem
    {
        public int Index { get; set; }
        public int Id { get; set; }
        public string Person { get; set; }
        public string Group { get; set; }
    }
}
