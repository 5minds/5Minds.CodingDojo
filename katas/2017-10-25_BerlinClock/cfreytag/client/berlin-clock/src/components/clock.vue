<template>
  <div class="clock">
    <div class="seconds"></div>
    <stripes class="hours-base-five" :active="berlintime.hoursBaseFive" :total="4"></stripes>
    <stripes class="hours-remainder" :active="berlintime.hoursBaseRemainder" :total="4"></stripes>
    <stripes class="minutes-base-five" :active="berlintime.minutesBaseFive" :total="11" :devisions="3"></stripes>
    <stripes class="minutes-remainder" :active="berlintime.minutesBaseRemainder" :total="4"></stripes>
  </div>
</template>

<script>
import berlinClockApi from '../api/berlinClock';
import stripes from './stripes';

export default {
  name: 'BerlinClock',
  components: {
    stripes,
  },
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
  created() {
    this.getBerlinTime();
    setInterval(
      this.getBerlinTime,
      60000
    );
  },
  methods: {
    getBerlinTime() {
      berlinClockApi.getTime().then(
        (response) => {
          this.berlintime = response.data;
        }
      );
    }
  }
  
}
</script>
<style lang="scss">
@keyframes animSeconds {
   0% { background-color: hsl(40deg, 100%, 50%);}
   20% { background-color: hsl(40deg, 100%, 20%);}
   100% { background-color: hsl(40deg, 100%, 20%);}
}
  .clock {
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  .seconds {
    width: 30px;
    height: 30px;
    border-radius: 50%;
    border-width: 1px;
    border-color: black;
    border-style: solid;
    margin: 5px;
    animation: animSeconds 1s infinite;
  }
  .minutes-base-five, .minutes-remainder {
    &.group {
      .element {
        background-color: hsl(40deg, 100%, 20%);
        
        &.active {
          background-color: hsl(40deg, 100%, 50%);
        }

        &.devider {
            background-color: hsl(0deg, 100%, 20%);
            &.active {
                background-color: hsl(0deg, 100%, 50%);
            }
        }
      }
    }
  }
</style>
