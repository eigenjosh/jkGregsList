<template>
    <div class="animal">
        <router-link :to="{name: 'home'}">Return to Home</router-link>
        <div class="animals row">
            <div v-for="animal in animals" class="col-sm-4">
                <img :src="animal.imgUrl" alt="a animal">
                <p>Type: {{animal.price}} - {{animal.description}}</p>
                <router-link :to="{name: 'details', params: {animalId: animal.id}}">Description</router-link>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Animals',
        data() {
            return {
            }
        },
        computed: {
            animals() {
                return this.$store.state.animals
            }
        }
    }
</script>

<style>
</style>