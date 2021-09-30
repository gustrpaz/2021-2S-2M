define("_oss/lighthouse/lighthouse-core/audits/metrics/cumulative-layout-shift",["exports"],(function(n){
/**
   * @license Copyright 2019 The Lighthouse Authors. All Rights Reserved.
   * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
   * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
   */
n.defaultOptions={p10:.1,median:.25}}));
define("_oss/lighthouse/lighthouse-core/audits/metrics/first-contentful-paint",["exports"],(function(n){
/**
   * @license Copyright 2018 The Lighthouse Authors. All Rights Reserved.
   * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
   * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
   */
n.defaultOptions={mobile:{scoring:{p10:1800,median:3e3}},desktop:{scoring:{p10:934,median:1600}}}}));
define("_oss/lighthouse/lighthouse-core/audits/metrics/interactive",["exports"],(function(n){
/**
   * @license Copyright 2017 The Lighthouse Authors. All Rights Reserved.
   * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
   * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
   */
n.defaultOptions={mobile:{scoring:{p10:3785,median:7300}},desktop:{scoring:{p10:2468,median:4500}}}}));
define("_oss/lighthouse/lighthouse-core/audits/metrics/largest-contentful-paint",["exports"],(function(n){
/**
   * @license Copyright 2019 The Lighthouse Authors. All Rights Reserved.
   * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
   * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
   */
n.defaultOptions={mobile:{scoring:{p10:2500,median:4e3}},desktop:{scoring:{p10:1200,median:2400}}}}));
define("_oss/lighthouse/lighthouse-core/audits/metrics/total-blocking-time",["exports"],(function(n){
/**
   * @license Copyright 2019 The Lighthouse Authors. All Rights Reserved.
   * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
   * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
   */
n.defaultOptions={mobile:{scoring:{p10:200,median:600}},desktop:{scoring:{p10:150,median:350}}}}));
define("_oss/lighthouse/lighthouse-core/config/default-config",["exports"],(function(n){
/**
     * @license Copyright 2018 The Lighthouse Authors. All Rights Reserved.
     * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
     * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
     */
"use strict";const t={};n.auditRefs=[{id:"first-contentful-paint",weight:10,group:"metrics",acronym:"FCP",relevantAudits:t.fcpRelevantAudits},{id:"speed-index",weight:10,group:"metrics",acronym:"SI"},{id:"largest-contentful-paint",weight:25,group:"metrics",acronym:"LCP",relevantAudits:t.lcpRelevantAudits},{id:"interactive",weight:10,group:"metrics",acronym:"TTI"},{id:"total-blocking-time",weight:30,group:"metrics",acronym:"TBT",relevantAudits:t.tbtRelevantAudits},{id:"cumulative-layout-shift",weight:15,group:"metrics",acronym:"CLS",relevantAudits:t.clsRelevantAudits},]}));
define("_oss/lighthouse/lighthouse-core/lib/statistics",["exports"],(function(n){
/**
 * @license Copyright 2017 The Lighthouse Authors. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
 */
function t(n){const i=Math.sign(n);n=Math.abs(n);const t=1/(1+.3275911*n),r=t*(.254829592+t*(-.284496736+t*(1.421413741+t*(-1.453152027+t*1.061405429))));return i*(1-r*Math.exp(-n*n))}function i({median:n,p10:i},r){if(n<=0)throw new Error("median must be greater than zero");if(i<=0)throw new Error("p10 must be greater than zero");if(i>=n)throw new Error("p10 must be less than the median");if(r<=0)return 1;const u=Math.log(r/n),f=-Math.log(i/n),e=u*.90619380243682324/f,o=(1-t(e))/2;return Math.min(1,Math.max(0,o))}n.getLogNormalScore=i}));
define("@microsoft/azureportal-reactview/internal/LighthouseNormalization",["require","exports","_oss/lighthouse/lighthouse-core/audits/metrics/first-contentful-paint","_oss/lighthouse/lighthouse-core/audits/metrics/largest-contentful-paint","_oss/lighthouse/lighthouse-core/audits/metrics/interactive","_oss/lighthouse/lighthouse-core/audits/metrics/total-blocking-time","_oss/lighthouse/lighthouse-core/audits/metrics/cumulative-layout-shift","_oss/lighthouse/lighthouse-core/config/default-config","_oss/lighthouse/lighthouse-core/lib/statistics"],(function(n,t,i,r,u,f,e,o,s){"use strict";function p(n,t){var i=s.getLogNormalScore(a[n],t),r=y[n];return{score:i*r,maxScore:r,utilizedPercent:i*100}}function l(n){return o.auditRefs.find((function(t){var i=t.id;return i===n})).weight+v}var h,c;Object.defineProperty(t,"__esModule",{value:!0});t.normalizeMetric=void 0;var a=(h={},h.FirstContentfulPaint=i.defaultOptions.desktop.scoring,h.LargestContentfulPaint=r.defaultOptions.desktop.scoring,h.TimeToInteractive=u.defaultOptions.desktop.scoring,h.TotalBlockingTime=f.defaultOptions.desktop.scoring,h.CumulativeLayoutShift=e.defaultOptions,h),v=o.auditRefs.find((function(n){var t=n.id;return t==="speed-index"})).weight/5,y=(c={},c.FirstContentfulPaint=l("first-contentful-paint"),c.LargestContentfulPaint=l("largest-contentful-paint"),c.TimeToInteractive=l("interactive"),c.TotalBlockingTime=l("total-blocking-time"),c.CumulativeLayoutShift=l("cumulative-layout-shift"),c);t.normalizeMetric=p}))