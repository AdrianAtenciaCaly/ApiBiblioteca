<template>
  <div>
    <h1 class="display-4 text-center">Listado Usuarios</h1>
    <hr>
    <div class="row">
      <div class="col-lg-8 offset-lg-2">
        <div class="card mt-4">
          <div class="card-body">
            <div class="input-group">
              <input type="text" v-model="names" class="form-control form-control-lg" placeholder="Nombres"/>
                           <input type="text" v-model="surnames" class="form-control form-control-lg" placeholder="Apellidos"/>

              <div class="input-group-append">
                <button v-on:click = "agregarUsuario" class="btn btn-success btn-lg">Agregar</button>
              </div>
            </div>
            <br>
          <div class="text-center">
          <div  v-if = "loading" class="spinner-border text-success" role="status">
            <span class="sr-only">Loading...</span>
          </div>
          </div>
            <h4 v-if="listUsuarios.length == 0">No hay Usuario</h4>
            <ul v-if="!loading" class="list-group">
              <li v-for="(usuario,index) of listUsuarios" :key="index" class="list-group-item d-flex justify-content-between"> 
                {{usuario.names}}
                 {{usuario.surnames}}
                <span  v-on:click="eliminarUsuario(usuario.id)" class="text-danger cursor"><i class="far fa-trash-alt"></i></span>
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
      names: '',
       surnames: '',
      listUsuarios :[],
      loading : false
    }
  },
  methods:{
    agregarUsuario(){
      const usuario = {
        names: this.names,
        surnames : this.surnames
   
      }
      this.loading = true
      axios.post("https://localhost:44381/api/Usuario/", usuario).then(renponse=>{
       console.log(renponse);
       this.loading = false;
      this.obtenerUsuario();
     }).catch(error=> {
       console.error(error);
       this.loading= false;
     });
      this.tarea = ''
    },
    eliminarUsuario(id){
     this.loading = true;
     axios.delete("https://localhost:44381/api/Usuario/" + id).then(renponse=>{
       console.log(renponse);
        this.loading = false;
       this.obtenerUsuario();

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

    }
  },
  created: function(){
    this.obtenerUsuario();
  }
};
</script>

<style scoped>
.cursor{
  cursor: pointer;
}
</style>
