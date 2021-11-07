<template>
  <div class="clock">
    <div class="seconds"></div>
    <ul class="Hours-Base-Five">
      <li class="active" v-for="hour in hoursBaseFive" :key="hour"></li>
      <li v-for="n in hoursBaseFiveInactives" :key="n"><li>
    </ul>
    <ul class="Hours-Base-Five-Remainder">
      <li></li>
    </ul>
    <ul class="Minutes-Base-Five">
      <li></li>
    </ul>
    <ul class="Minutes-Base-Five-Remainder">
      <li></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'BerlinClock',
  props: {
    msg: String,
    berlinClockTime: BerlinClockFormat,
  },
  data: {

  },
  computed: {
    hoursFiveInactives: 4 - berlinClockTime.hours,
    hoursRemainderInactives: 4 - berlinClockTime.hoursRemainder,
    minutesFiveInactives: 11 - berlinClockTime.minutes,
    minutesRemainderInactives: 4 - berlinClockTime.minutesRemainder,
  }
  
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
