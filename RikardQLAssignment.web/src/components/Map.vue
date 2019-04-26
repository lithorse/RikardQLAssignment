<template>
  <div>
    <button @click="getMarkers">Read</button>
    <button @click="clearMarkers">Clear</button>
    <GmapMap :center="center" :zoom="3" map-type-id="hybrid" style="width: 100%; height: 900px" :options="{fullscreenControl: false, streetViewControl: false, mapTypeControl: false}">
        <GmapMarker :key="index" v-for="(m, index) in markers" :position="m.position" :clickable="true" @click="center=m.position"/>
    </GmapMap>
  </div>
</template>

<script>
import {positionService} from '../shared/services'
export default {
  name: 'Map',
  data(){
      return {
        center: { lat: 0, lng: 0 },
        markers: []
      }
  },
  methods: {
      getMarkers(){
          positionService.getPositions().then(data => {
              data.forEach(position => {
                this.markers.push({position: { lat: parseFloat(position.latitude), lng: parseFloat(position.longitude) }})
            });
          });
      },
      clearMarkers(){
          this.markers = []
      }
  }
}
</script>