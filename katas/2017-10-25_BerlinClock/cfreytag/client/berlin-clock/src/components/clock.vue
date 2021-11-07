<template>
  <div class="clock">
    <div class="seconds"></div>
    <ul class="Hours-Base-Five">
      <li class="active" v-for="hours in berlintime.hoursBaseFive" :key="hours"></li>
      <li v-for="n in hoursFiveInactives" :key="n"></li>
    </ul>
    <ul class="Hours-Base-Five-Remainder">
      <li class="active" v-for="remainder in berlintime.hoursBaseRemainder" :key="remainder"></li>
      <li v-for="n in hoursRemainderInactives" :key="n"></li>
    </ul>
    <ul class="Minutes-Base-Five">
      <li class="active" v-for="minutes in berlintime.minutesBaseFive" :key="minutes"></li>
      <li v-for="n in minutesFiveInactives" :key="n"></li>
    </ul>
    <ul class="Minutes-Base-Five-Remainder">
      <li class="active" v-for="remainder in berlintime.minutesBaseRemainder" :key="remainder"></li>
      <li v-for="n in minutesRemainderInactives" :key="n"></li>
    </ul>
  </div>
</template>

<script>
import berlinClockApi from '../api/berlinClock';
export default {
  name: 'BerlinClock',
  data() {
    return {
      berlintime: {
        hoursBaseFive:0,
        hoursBaseRemainder:0,
        minutesBaseFive:0,
        minutesBaseRemainder:0,
      }
    }
  },
  computed: {
    //hoursFiveInactives: 4 - berlinClockTime.hoursBaseFive,
    //hoursRemainderInactives: 4 - berlinClockTime.hoursBaseRemainder,
    //minutesFiveInactives: 11 - berlinClockTime.minutesBaseFive,
    //minutesRemainderInactives: 4 - berlinClockTime.minutesBaseRemainder,
    hoursFiveInactives () { return (4 - this.berlintime.hoursBaseFive)},
    hoursRemainderInactives () { return (4 - this.berlintime.hoursBaseRemainder)},
    minutesFiveInactives () { return (11 - this.berlintime.minutesBaseFive)},
    minutesRemainderInactives () { return (4 - this.berlintime.minutesBaseRemainder)},
  },
  created() {
    berlinClockApi.getTime().then((response) => {
      console.log(response.data);
      this.berlintime = response.data
      });
  }
  
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style lang="scss" scoped>
  li {
    width: 200px;
    height:30px;
    background-color:orange;
    display:block;
    &.active {
      background-color: green;
    }
  }
</style>
