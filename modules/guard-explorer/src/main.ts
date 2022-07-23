import { createApp } from "vue";
import { createPinia } from "pinia";

import * as naive from "naive-ui";
import "vfonts/Lato.css";
import "vfonts/FiraCode.css";

import App from "./App.vue";
import router from "./router";

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(naive);
app.mount("#app");
