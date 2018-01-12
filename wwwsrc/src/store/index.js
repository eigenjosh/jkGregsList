import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

let api = axios.create({
    baseURL: 'http://localhost:5000/api/',
    timeout: 2000,
    withCredentials: true
})

let auth = axios.create({
    baseURL: 'http://localhost:5000/',
    timeout: 2000,
    withCredentials: true
})

Vue.use(Vuex)

var store = new Vuex.Store({
    state: {
        animals: {
        },
        autos: {
        },
        properties: {
        }
    },
    mutations: {
        setAnimals(state, data) {
            state.animals = data
        },
        handleError(state, err) {
            state.error = err
        }
    },
    actions: {
        getAnimals({ commit, dispatch }) {
            api('animals')
                .then(data => {
                    commit('setAnimals', data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getBoard({ commit, dispatch }, id) {
            api('boards/' + id)
                .then(x => {
                    commit('setActiveBoard', x)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        createBoard({ commit, dispatch }, board) {
            api.post('boards/', board)
                .then(x => {
                    dispatch('getBoards')
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        removeBoard({ commit, dispatch }, board) {
            api.delete('boards/' + board._id)
                .then(x => {
                    this.getBoards()
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        handleError({ commit, dispatch }, err) {
            commit('handleError', err)
        }
    }
})

export default store