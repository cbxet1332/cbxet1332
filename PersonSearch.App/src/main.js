import Vue from 'vue'
import VueRouter from "vue-router";
Vue.use(VueRouter);

import moment from 'moment'

import App from './App.vue'
import Home from './components/Home.vue';
import Persons from './components/Persons.vue';
import WiringTest from './components/WiringTest/WiringTest.vue';
import UnderConstruction from './components/UnderConstruction.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/test', component: WiringTest },
    { path: '/persons', component: Persons },
    { path: '/groups', component: UnderConstruction },
    { path: '/person/:id', component: UnderConstruction, props: true },
    { path: '/group/:id', component: UnderConstruction, props: true }
];

const router = new VueRouter({
    routes
});

Vue.config.productionTip = false;

Vue.filter('formatDate', function (value) {
    if (value) {
        return moment(String(value)).format('DD/MM/YYYY hh:mm:ss');
    }
});

new Vue({
    router,
    render: h => h(App)
}).$mount('#app');
