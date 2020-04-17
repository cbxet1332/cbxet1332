<template>
    <div class="btn-toolbar">
        <div id="list-pager-content" class="btn-group">
            <button class="btn btn-secondary" type="button" @click="onPrevClick" :disabled="!IsPrevEnabled">&nbsp;&lt;&nbsp;</button>
            <button class="btn btn-secondary" type="button" @click="onNextClick" disabled>&nbsp;{{ CurrentPage }}&nbsp;</button>
            <button class="btn btn-secondary" type="button" @click="onNextClick" :disabled="!IsNextEnabled">&nbsp;&gt;&nbsp;</button>
        </div>
    </div>
</template>

<script>
    export default {
        name: "list-pager",
        inject: ['connect'],
        created: function () {
            this.vm = this.connect("ListPager", this, {
                watch: [ 'CurrentPage' ]
            });
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        data() {
            return {
                CurrentPage: 1,
                IsPrevEnabled: false,
                IsNextEnabled: true
            }
        },
        props: { },
        methods: {
            onPrevClick: function () {
                this.CurrentPage = this.CurrentPage - 1;
                //this.vm.$dispatch({ PageChange: this.CurrentPage });
            },
            onNextClick: function () {
                this.CurrentPage = this.CurrentPage + 1;
                //this.vm.$dispatch({ NextPage: this.CurrentPage });
            }
        }
    };
</script>

<style type="text/css">
    .small {
        font-size: small
    }
</style>

