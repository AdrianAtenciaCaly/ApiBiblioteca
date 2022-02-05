<template>

   <Libros />
     <Usuarios />
   <Reservas />
</template>

<script>
import Libros from "./components/Libros";
import Usuarios from "./components/Usuarios";
import Reservas from "./components/Reservas";
export default {
  name: "App",
  components: {
    Reservas,
    Libros,
    Usuarios,
  },
};
</script>

<style></style>
