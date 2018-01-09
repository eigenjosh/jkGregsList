import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

var store = new Vuex.Store({
    state: {
        autos: {
            'lk34kl4lk234blk23b4bjk': {
                id: 'lk34kl4lk234blk23b4bjk',
                make: 'For',
                model: 'Mustard',
                color: 'grey poupon',
                description: 'Do you have this car? Its grey poupon get it!!!',
                imgUrl: 'http://loremflickr.com/200/200/car'
            },
            'lk34kwsefdceev234blk23b4bjk': {
                id: 'lk34kwsefdceev234blk23b4bjk',
                make: 'Cevy',
                model: 'Oregon',
                color: 'Tree',
                description: "Smells of coffee and beard oil",
                imgUrl: 'http://loremflickr.com/200/200/car'
            },
            'lk34kl4lk235sef541b4125bjk': {
                id: 'lk34kl4lk235sef541b4125bjk',
                make: 'Doge',
                model: 'Bark',
                color: 'Much Happy',
                description: "Such speed, fastness, wow!",
                imgUrl: 'http://loremflickr.com/200/200/car'
            }

        },
        animals: {
            'cat': {
                Id: 'cat1',
                Name: 'felix',
                Description: 'attacks anything that moves',
                Price: 'free'
            }
        }
    },
    mutations: {},
    actions: {}
})

export default store