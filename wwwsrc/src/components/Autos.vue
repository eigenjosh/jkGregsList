
<template>
    <div class="auto">
        <router-link :to="{name: 'home'}">Return to Home</router-link>
        <div class="autos row">
            <div v-for="auto in autos" class="col-sm-4">
                <img :src="auto.imgUrl" alt="a auto">
                <p>Type: {{auto.make}} - {{auto.model}}</p>
                <router-link :to="{name: 'details', params: {autoId: auto.id}}">Description</router-link>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Auto',
        data(){
            return {
            }
        },
        computed: {
            autos(){
                return this.$store.state.autos
            }
        }
    }
</script>

<style>
</style>