<template>
    <div class="btn-toolbar">
        <div id="list-pager-content" class="btn-group">
            <button class="btn btn-secondary" type="button" @click="onFirstClick" :disabled="CurrentPage == 1">&nbsp;&lt;&lt;&nbsp;</button>
            <button class="btn btn-secondary" type="button" @click="onPrevClick" :disabled="CurrentPage == 1">&nbsp;&lt;&nbsp;</button>
            <button class="btn btn-secondary" type="button" @click="onNextClick" :disabled="CurrentPage == TotalPages">&nbsp;&gt;&nbsp;</button>
            <button class="btn btn-secondary" type="button" @click="onLastClick" :disabled="CurrentPage == TotalPages">&nbsp;&gt;&gt;&nbsp;</button>
        </div>
        <div id="current-page">{{CurrentPage}}/{{TotalPages}}</div>
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
                TotalPages: 1
            }
        },
        props: { },
        methods: {
            onPrevClick: function () {
                this.CurrentPage = this.CurrentPage - 1;
            },
            onNextClick: function () {
                this.CurrentPage = this.CurrentPage + 1;
            },
            onFirstClick: function () {
                this.CurrentPage = 1;
            },
            onLastClick: function () {
                this.CurrentPage = this.TotalPages;
            }
        }
    };
</script>

<style type="text/css">
    .small {
        font-size: small
    }
    #current-page {
        margin-top: 8px;
        margin-left: 8px;
    }
</style>

