<template>
  <header class="p-3 bg-dark text-white">
    <div id="nav">
      <div class="d-flex flex-wrap justify-content-center">
        <div class="d-flex justify-content-lg-start">
          <button type="button" class="btn btn-outline-light me-2" disabled>
            <i class="fa fa-user-circle-o"></i>
            <span>{{ user_account }}</span>
          </button>
          <button
            type="button"
            class="btn btn-outline-light me-2"
            v-on:click="home"
          >
            <i class="fa fa-home"></i> Home
          </button>
          <button
            type="button"
            id="chatrooms"
            class="btn btn-outline-light me-2"
            v-on:click="statements"
            :disabled="authorized_user"
          >
            Statements
          </button>
        </div>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {
      authorized_user: false,
      user_account: "registrar",
    };
  },
  methods: {
    async home() {
      this.$router.push({ name: "Home" }).catch(() => {});
    },
    async statements() {
      this.$router.push({ name: "Statements" }).catch(() => {});
    },
  },
};
</script>
