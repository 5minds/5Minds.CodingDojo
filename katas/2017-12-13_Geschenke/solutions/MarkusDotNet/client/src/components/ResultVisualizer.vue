<template>
  <div class="result-visualizer">
      <h4>Oh ho!</h4>
      <p>{{resultText}}</p>
      <p>{{resultPresentsText}}</p>
      <p>{{resultEfficiencyText}}</p>
      <hr/>
      <p>{{resultPathText}}</p>
  </div>
</template>

<script>
export default {
    name: "result-visualizer",
    props: {   
        visitedCount: {type: Number, default: 0},
        uniqueVisitedCount:{type: Number, default: 0},
        completePath: {type: Array, default: ()=>[]},
        uniqueVisits: {type: Array, default: ()=>[]},
    },
    computed: {
        maxMapCoordinates(){
            return this.completePath.reduce((c,coordString) => {
                const newCoords = c;
                const coords = coordString.split(":").map(parseInt);
                if(c[0]<coords[0]) {
                    newCoords[0]=coords[0];
                }
                if(c[1]<coords[1]) {
                    newCoords[1]=coords[1];
                }
                return newCoords;
            },[0,0])
        },
        minMapCoordinates(){
            return this.completePath.reduce((c,coordString) => {
                const newCoords = c;
                const coords = coordString.split(":").map(parseInt);
                if(c[0]>coords[0]) {
                    newCoords[0]=coords[0];
                }
                if(c[1]>coords[1]) {
                    newCoords[1]=coords[1];
                }
                return newCoords;
            },[0,0])
        },
        efficiency(){
            return Math.round((this.visitedCount/this.uniqueVisitedCount)*100)/100;
        },
        resultText() {
            return `Ich habe ${this.uniqueVisitedCount || 0} Häuser besucht!`;
        },
        resultPresentsText() {
            return `Ich habe dabei ${this.visitedCount || 0} Geschenke verteilt!`;
        },
        resultEfficiencyText() {
            return `Das heißt ich habe an einem Haus durchschnittlich ${this.efficiency} Geschenke verteilt`;
        },
        resultPathText() {
            return `Ich bin von x=${this.minMapCoordinates[0]} und y=${this.minMapCoordinates[1]}, bis nach x=${this.maxMapCoordinates[0]} und y=${this.maxMapCoordinates[1]}`;
        },
    }
}
</script>

<style>

</style>