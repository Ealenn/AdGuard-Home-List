import axios from "axios";
import { defineStore } from "pinia";

export const listsStore = defineStore({
  id: "list",
  state: () => ({
    loading: true,
    totalProgress: 0,
    progress: 0,
    list: [],
    allowListSize: 0,
    blockListSize: 0,
    searchItem: "",
  }),
  getters: {
    getList: (state) => state.list,
    getAllowListSize: (state) => state.allowListSize,
    getBlockListSize: (state) => state.blockListSize,
    getProgress: (state) => state.progress,
    getTotalProgress: (state) => state.totalProgress,
    getLoading: (state) => state.loading,
    getSearchItem: (state) => state.searchItem,
  },
  actions: {
    fetchList() {
      this.loading = true;
      this.progress = 0;

      axios
        .get(
          "https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/AdGuard-Home-List.Allow.txt"
        )
        .then((response) => {
          this.progress += 50;
          const list = response.data.split("\n");
          this.allowListSize = list.length;
          this.list = this.list.concat(
            list.map((item: string) => ({
              rule: item,
              from: "",
            }))
          );

          this.progress += 50;
          if (this.progress === 100) {
            this.loading = false;
          }
        });

      // TODO: Resolve this perf issue
      // axios
      //   .get(
      //     "https://raw.githubusercontent.com/Ealenn/AdGuard-Home-List/gh-pages/AdGuard-Home-List.Block.txt"
      //   )
      //   .then((response) => {
      //     this.progress += 40;
      //     const list = response.data.split("\n");
      //     this.blockListSize = list.length;
      //     this.list = this.list.concat(
      //       list.map((item: string) => ({
      //         rule: item,
      //         from: "",
      //       }))
      //     );

      //     this.progress += 10;
      //     if (this.progress === 100) {
      //       this.loading = false;
      //     }
      //   });
    },
    search(value: string) {
      this.searchItem = value;
    },
  },
});
