<template>
    <main>
      <n-space justify="space-around" style="margin-top:50px" v-if="isLoading">
        <n-progress type="circle" :percentage="progress">
          <span style="text-align: center">Downloading...</span>
        </n-progress>
      </n-space>

      <n-space justify="space-around" style="margin-top:50px" v-if="!isLoading">
        <n-statistic label="Allowed" :value="allowListSize">
          <template #prefix>
            <n-icon color="#0e7a0d" :component="LockOpenOutline" />
          </template>
        </n-statistic>

        <n-statistic label="Blocked" :value="blockListSize">
          <template #prefix>
            <n-icon color="#FF5733 " :component="LockClosedOutline" />
          </template>
        </n-statistic>
      </n-space>

      <n-space vertical style="margin-top:50px">
        <n-input size="large" round placeholder="Search..." :on-update:value="(value: string) => store.search(value)"  v-if="!isLoading">
          <template #suffix>
            <n-icon :component="SearchOutline" />
          </template>
        </n-input>
      </n-space>

      <n-space vertical style="margin-top:50px" v-if="!isLoading">
        <n-data-table
          :columns="columns"
          :data="data"
          :max-height="300"
          :scroll-x="1800"
          virtual-scroll
        />
      </n-space>
    </main>
</template>

<script setup lang="ts">
import { listsStore } from '@/stores/lists';
import { SearchOutline, LockClosedOutline, LockOpenOutline } from '@vicons/ionicons5'
import type { DataTableColumns } from 'naive-ui';
import { computed } from 'vue';
const store = listsStore();

type RowData = {
  rule: string
  from: number
}
const columns: DataTableColumns<RowData> = [
  {
    title: 'Rule',
    key: 'rule',
    fixed: 'left'
  },
  {
    title: 'From',
    key: 'from',
    width: 200,
    fixed: 'right'
  }
]

const data = computed(() => {
  return store.getList.filter((x: RowData) => x.rule.includes(store.getSearchItem));
});

const allowListSize = computed(() => {
  return store.getAllowListSize;
});

const blockListSize = computed(() => {
  return store.getBlockListSize;
});

const isLoading = computed(() => {
  return store.getLoading
});

const progress = computed(() => {
  return store.getProgress
});
</script>
