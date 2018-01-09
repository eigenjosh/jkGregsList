
<template>
    <div class="property">
        <router-link :to="{name: 'home'}">Return to Home</router-link>
        <div class="properties row">
            <div v-for="property in properties" class="col-sm-4">
                <img :src="property.imgUrl" alt="a property">
                <p>Type: {{property.species}} - {{property.name}}</p>
                <router-link :to="{name: 'details', params: {propertyId: property.id}}">Description</router-link>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Property',
        data(){
            return {
            }
        },
        computed: {
            properties(){
                return this.$store.state.properties
            }
        }
    }
</script>

<style>
</style>