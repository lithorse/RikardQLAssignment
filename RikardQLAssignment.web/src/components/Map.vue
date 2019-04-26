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
export default {
  name: 'Map',
  data(){
      return {
        center: { lat: 0, lng: 0 },
        markers: [],
        places: [],
        currentPlace: null
      }
  },
  methods: {
      getMarkers(){
          //TODO: Get markers from backend
          var positions = getPositions();
          this.markers.push({position: { lat: 45.508, lng: -73.587 }}, {position: { lat: 28.508, lng: -28.587 }})
      },
      clearMarkers(){
          this.markers = []
      }
  }
}
</script>