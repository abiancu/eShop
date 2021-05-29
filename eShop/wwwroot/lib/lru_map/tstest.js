"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const lru_1 = require("./lru");
let m = new lru_1.LRUMap(3);
let entit = m.entries();
let k = entit.next().value[0];
let v = entit.next().value[1];
