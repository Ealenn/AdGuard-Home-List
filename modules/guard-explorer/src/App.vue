<script setup lang="ts">
import { RouterView } from 'vue-router'
import { darkTheme } from 'naive-ui'
import { listsStore } from './stores/lists';
import { onMounted } from 'vue';
const store = listsStore();
onMounted(() => {
  store.fetchList();
})
</script>

<template>
  <n-config-provider :theme="darkTheme">
    <n-layout class="app-layout" position="absolute">
      <n-layout-content
        class="layout-content"
        style="border-radius: 0 16px 16px;"
      >
        <div style="padding: 20px 40px;">
          <RouterView />
        </div>
      </n-layout-content>
    </n-layout>
  </n-config-provider>
</template>
