import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Automotive from '@/components/Automotive'
import Properties from '@/components/Properties'
import Details from '@/components/Details'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/automotive',
      name: 'automotive',
      component: Automotive
    },
    {
      path: '/automotive/:carId',
      name: 'details',
      component: Details
    },
    {
      path: '/properties',
      name: 'properties',
      component: Properties
    }
  ]
})