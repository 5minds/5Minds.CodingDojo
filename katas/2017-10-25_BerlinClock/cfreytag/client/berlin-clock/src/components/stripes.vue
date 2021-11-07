<template>
    <div class="group">
        <div class="element" :class="{'active': n <= active, 'devider': (n%devisions) == 0}" v-for="n in total" :key="n"></div>
    </div>
</template>
<script>
    export default {
        name : "stripes",
        props: {
            active: Number,
            total: Number,
            devisions: Number,   
        }
    }
</script>
<style lang="scss">
    .group {
        width: 100%;
        display:flex;
        flex-direction: row;
        .element {
            width: 100%;
            min-height: 30px;
            border: 1px solid black;
            display: block;
            background-color: hsl(0deg, 100%, 20%);
            margin: 5px;
            &.active {
                background-color: hsl(0deg, 100%, 50%);
            }
            &.devider {
                background-color: hsl(0deg, 100%, 20%);
                &.active {
                    background-color: hsl(0deg, 100%, 50%);
                }
            }
        }
    }
</style>
