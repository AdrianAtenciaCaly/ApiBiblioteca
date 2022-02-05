<template>
  <div>
    <h1 class="display-4 text-center">Listado Libros</h1>
    <hr>
    <div class="row">
      <div class="col-lg-8 offset-lg-2">
        <div class="card mt-4">
          <div class="card-body">
            <div class="input-group">
              <input type="text" v-model="libroTitle" class="form-control form-control-lg" placeholder="Nombre del libro"/>
                       <input type="text" v-model="libroAuthor" class="form-control form-control-lg" placeholder="Autor"/>

            <input type="number" v-model="libroDateRelease" class="form-control form-control-lg" placeholder="Año de lanzamiento"/>
    
              <div class="input-group-append">
                <button v-on:click = "agregarLibro" class="btn btn-success btn-lg">Agregar</button>
              </div>
            </div>
            <br>
          <div class="text-center">
          <div  v-if = "loading" class="spinner-border text-success" role="status">
            <span class="sr-only">Loading...</span>
          </div>
          </div>
            <h4 v-if="listLibros.length == 0">No hay Libros</h4>
            <ul v-if="!loading" class="list-group">
              <li v-for="(libro,index) of listLibros" :key="index" class="list-group-item d-flex justify-content-between">
                <span  class="cursor" v-bind:class ="{'text-success' : libro.reserve_status}" >
                  <i v-bind:class ="[libro.reserve_status ? 'fas fa-check-circle' : 'far fa-circle']"></i>
                 </span>
                {{libro.title}}
                       {{libro.author}}
                              {{libro.release_date}}
                <span  v-on:click="eliminarLibro(libro.id)" class="text-danger cursor"><i class="far fa-trash-alt"></i></span>
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
  name: "Libro",
  data(){
    return {
      libroTitle: '',
      libroAuthor: '',
      libroDateRelease: '',
      listLibros :[],
      loading : false
    }
  },
  methods:{
    agregarLibro(){
      const libro = {
        title: this.libroTitle,
        author: this.libroAuthor,
        release_date: this.libroDateRelease,
        reserve_status: false
      }
      this.loading = true
      axios.post("https://localhost:44381/api/Libro/", libro).then(renponse=>{
       console.log(renponse);
       this.loading = false;
this.obtenerLibros();
     }).catch(error=> {
       console.error(error);
       this.loading= false;
     });
      this.tarea = ''
    },
    eliminarLibro(id){
     this.loading = true;
     axios.delete("https://localhost:44381/api/Libro/" + id).then(renponse=>{
       console.log(renponse);
        this.loading = false;
       this.obtenerLibros();

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
    this.obtenerLibros();
  }
};
</script>

<style scoped>
.cursor{
  cursor: pointer;
}
</style>
