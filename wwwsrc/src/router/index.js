import Vue from 'vue'
import Router from 'vue-router'
import Animals from '@/components/Animals'
// import Home from '@/components/Home'
// import Properties from '@/components/Properties'
// import Details from '@/components/Details'

Vue.use(Router)

export default new Router({
  routes: [
    // {
    //   path: '/',
    //   name: 'home',
    //   component: Home
    // },
    {
      path: '/animals',
      name: 'animals',
      component: Animals
    }
    // {
    //   path: '/automotive/:carId',
    //   name: 'details',
    //   component: Details
    // },
    // {
    //   path: '/properties',
    //   name: 'properties',
    //   component: Properties
    // }
  ]
})