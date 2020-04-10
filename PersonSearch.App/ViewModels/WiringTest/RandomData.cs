using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DotNetify;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PersonSearch.Data;
using PersonSearch.Domain;

namespace PersonSearch.App.ViewModels.WiringTest
{
    [UsedImplicitly]
    public class RandomData : BaseVM
    {
        private readonly IRepository<Person> _personRepository;
        private Random _random;
        private readonly Timer[] _timers;
        private readonly RandomDataItem[] _randomDataItems;
        private int[] _indexes;
        private int[] _timerIntervals;
        private int _personCount = 0;

        public RandomData(IRepository<Person> personRepository, IApplicationDbContextFactory contextFactory)
        {
            _random = new Random();
            _personRepository = personRepository;

            using (var context = contextFactory.Create(QueryTrackingBehavior.NoTracking))
            {
                _personCount = personRepository.Count(context);
            }

            _indexes = new[] {0, 1}; 
            _timerIntervals = new[] { 3000, 5000 };
            _randomDataItems = _indexes.Select(_ => (RandomDataItem)null).ToArray();
            _timers = _indexes.Select(index => new Timer(state =>
            {
                var randomPersonIndex = GetNewRandomIndex();
                using (var context = contextFactory.Create(QueryTrackingBehavior.NoTracking))
                {
                    _randomDataItems[index] = _personRepository
                        .SkipTake(randomPersonIndex, 1, context, person => person.Group)
                        .ToList()
                        .Select(person => new RandomDataItem
                        {
                            Index = index,
                            Id = person.Id,
                            Person = $"{person.Forenames} {person.Surname}",
                            Group = person.Group.Name
                        })
                        .First();
                }
                Changed(nameof(Data));
                PushUpdates();
            }, null, 0, _timerIntervals[index])).ToArray();
        }

        public IEnumerable<RandomDataItem> Data => _randomDataItems.Where(dataItem => dataItem != null);

        public override void Dispose()
        {
            _timers[0].Dispose();
            _timers[1].Dispose();
        }

        private int GetNewRandomIndex()
        {
            int index;
            do
            {
                index = _random.Next(0, _personCount - 1);
            } while (Data.Any(item => item.Id == index));

            return index;
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
