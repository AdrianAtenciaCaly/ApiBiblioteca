<template>
  <div>
    <h1 class="display-4 text-center">Reservas</h1>
    <hr>
    <div class="row">
      <div class="col-lg-8 offset-lg-2">
        <div class="card mt-4">
          <div class="card-body">
            <div class="input-group">
              <div class="form-control-lg">
             <select  class="form-select"  v-model="selecteduser">
                <option disabled selected >
   SELEECIONES UNA OPCIÓN
  </option>
            <option v-for="(usuario,index) of listUsuarios" :key="index" v-bind:value="usuario.id">
            {{ usuario.names }}
                 </option>
</select>
            </div>
<div class="form-control-lg">
 <select class="form-select"  v-model="selectedbook">
     <option disabled selected >
   SELEECIONES UNA OPCIÓN
  </option>
            <option v-for="(libro,index) of listLibros" :key="index" v-bind:value="libro.id">
            {{ libro.title }} {{ libro.reserve_status }}
                 </option>
</select>
          </div>
              <div class="input-group-append">
                <button v-on:click = "agregarReserva" class="btn btn-success btn-lg">Agregar</button>
              </div>
            </div>
            <br>
          <div class="text-center">
          <div  v-if = "loading" class="spinner-border text-success" role="status">
            <span class="sr-only">Loading...</span>
          </div>
          </div>
            <h4 v-if="listReserva.length == 0">No hay Usuario</h4>
            <ul v-if="!loading" class="list-group">
              <li v-for="(reserva,index) of listReserva" :key="index" class="list-group-item d-flex justify-content-between"> 
                {{reserva.idLibro}}

                 {{reserva.idUsuario}}
                <span  v-on:click="eliminarReserva(reserva.id)" class="text-danger cursor"><i class="far fa-trash-alt"></i></span>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import axios from "axios";
export default {
  name: "Usuario",
  data(){
    return {
      idLibro: '',
       idUsuario: '',
      listReserva :[],
       listUsuarios :[],
       listLibros:[],
     
      loading : false
    }
  },
  methods:{
    agregarReserva(){
      const reserva = {
        idLibro :this.selectedbook,
        idUsuario : this.selecteduser,
      }
      this.loading = true
      
      axios.post("https://localhost:44381/api/Reserva/", reserva).then(response=>{
       console.log(reserva.idLibro);
console.log(response)
      this.actualizaReserva(reserva.idLibro);
      this.obtenerLibros();
      this.obtenerUsuario();
      this.selectedbook='';
      this.selecteduser = '';
       this.loading = false;
      this.obtenerReserva();
     }).catch(error=> {
       console.error(error);
       this.loading= false;
     });
      this.tarea = ''
    },
    eliminarReserva(id){
     this.loading = true;
     axios.delete("https://localhost:44381/api/Reserva/" + id).then(response=>{
      console.log(response);
        this.loading = false;
       this.obtenerReserva();
     }).catch(error=> {
       console.log(error);
        this.loading = false;
     });
    },
 
    actualizaReserva(id){
          this.loading = true;
          console.log("entro"+id); 
      axios.put("https://localhost:44381/api/Libro/"+id).then(response=> {
         console.log(response);
        this.obtenerReserva();
            this.loading = false;
      }).catch(error=> {
       console.log(error);
        this.loading = false;
     });

    },

    obtenerReserva(){
          this.loading = true;
      axios.get("https://localhost:44381/api/Reserva").then(response=> {
    
        this.listReserva = response.data;
            this.loading = false;
      }).catch(error=> {
       console.log(error);
        this.loading = false;
     });

    },
    obtenerUsuario(){
          this.loading = true;
      axios.get("https://localhost:44381/api/Usuario").then(response=> {
        console.log("error"+response.data);
        this.listUsuarios = response.data;
            this.loading = false;
      }).catch(error=> {
       console.log(error);
        this.loading = false;
     });

    },
    obtenerLibros(){
          this.loading = true;
      axios.get("https://localhost:44381/api/Libro").then(response=> {
        console.log("error"+response.data);
        this.listLibros = response.data;
            this.loading = false;
      }).catch(error=> {
       console.log(error);
        this.loading = false;
     });

    }
  },
  created: function(){
  this.obtenerReserva();
    this.obtenerUsuario();
    this.obtenerLibros();
  }
};
</script>

<style scoped>
.cursor{
  cursor: pointer;
}
</style>
