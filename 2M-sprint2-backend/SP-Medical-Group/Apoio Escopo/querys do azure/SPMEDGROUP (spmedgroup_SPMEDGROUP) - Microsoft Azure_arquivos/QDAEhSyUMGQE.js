define("MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/MetricsProvider/Draft/DraftMetadataUtils",["require","exports","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/Strings","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Utilities/Util"],(function(n,t,i,r){"use strict";function s(n){return n.substring(0,t.DraftCustomDimensionPrefix.length)===t.DraftCustomDimensionPrefix}function h(n){if(!u){u=[];var i;Object.keys(t.DraftAggregationValueToEnumNames).forEach((function(n){i=t.DraftAggregationValueToEnumNames[n];u[i]=n}))}return u[n]}function c(n,i,r){for(var e,u,o=[],f=0,s=n;f<s.length;f++)e=s[f],e&&(u=t.DraftAggregationValueToEnumNames[e],u&&(i||r!==4||u!==1&&u!==7)&&o.push(u));return o}function l(n){switch((n||"").toLowerCase()){case"ms":return 7;case"s":return 6;case"perSec":return 3;case"bytes":return 2;case"bytesPerSec":return 4;case"percent":return 5;default:return 1}}function a(n,t){var u=t&&t.metricId.name&&t.metricId.name.displayName,f,r,e;return u&&n[u]&&n[u].length>1&&(f=t.metricId.name.id.indexOf("/"),f>0&&(r=t.metricId.name.id.substring(0,f),e=i.DocumentType[r],(r||e)&&(t.metricId.name.displayName+=" ("+(e||r)+")"))),t}function v(n,t){var u=e||(e=p()),r=(t||o(n))&&i.DraftCategoryDisplayName.customEvent;return!r&&u[n]&&(r=u[n]),r||n.indexOf("performanceCounters/")!==0||(r=i.DraftCategoryDisplayName.performanceCounter),r}function o(n){return n.substring(0,f.length)===f||/[a-zA-Z]+\/custom\//.test(n)}function y(n){var u=t.DraftCustomDimensionPrefix+"[",i=n;return n&&n.indexOf(u)===0&&n[n.length-1]==="]"&&(i=t.DraftCustomDimensionPrefix+n.substring(u.length,n.length-1)),i=r.replaceAll(i,"\\]","]"),r.replaceAll(i,"\\\\","\\")}function p(){var n=i.DraftCategoryDisplayName;return{"availabilityResults/duration":n.availability,"availabilityResults/availabilityPercentage":n.availability,"availabilityResults/count":n.availability,"users/count":n.usage,"users/authenticated":n.usage,"sessions/count":n.usage,"requests/count":n.server,"requests/failed":n.failure,"requests/duration":n.server,"requests/rate":n.server,"exceptions/count":n.failure,"exceptions/browser":n.failure,"exceptions/server":n.failure,"dependencies/count":n.server,"dependencies/failed":n.failure,"dependencies/duration":n.server,"pageViews/count":n.usage,"pageViews/duration":n.usage,"browserTimings/totalDuration":n.client,"browserTimings/networkDuration":n.client,"browserTimings/sendDuration":n.client,"browserTimings/receiveDuration":n.client,"browserTimings/processingDuration":n.client,"customEvents/count":n.usage,"performanceCounters/processCpuPercentage":n.performanceCounter,"performanceCounters/memoryAvailableBytes":n.performanceCounter,"performanceCounters/requestsPerSecond":n.performanceCounter,"performanceCounters/exceptionsPerSecond":n.performanceCounter,"performanceCounters/processPrivateBytes":n.performanceCounter,"performanceCounters/processIOBytesPerSecond":n.performanceCounter,"performanceCounters/requestExecutionTime":n.performanceCounter,"performanceCounters/requestsInQueue":n.performanceCounter,"performanceCounters/processorCpuPercentage":n.performanceCounter,"performanceCounters/processCpuPercentageTotal":n.performanceCounter,"billingMeters/telemetryCount":n.usage,"billingMeters/telemetrySize":n.usage,"traces/count":n.usage}}var f,e,u;Object.defineProperty(t,"__esModule",{value:!0});t.getDraftDimensionKey=t.isCustomMetric=t.getDraftCategoryName=t.fixMetricDisplayName=t.convertDraftMetricUnit=t.getSupportedAggregations=t.getDraftAggregationValue=t.DraftAggregationValueToEnumNames=t.isCustomDimension=t.DraftCustomDimensionPrefix=void 0;f="customMetrics/";t.DraftCustomDimensionPrefix="customDimensions/";t.isCustomDimension=s;t.DraftAggregationValueToEnumNames={sum:1,min:2,max:3,avg:4,unique:5,count:7};t.getDraftAggregationValue=h;t.getSupportedAggregations=c;t.convertDraftMetricUnit=l;t.fixMetricDisplayName=a;t.getDraftCategoryName=v;t.isCustomMetric=o;t.getDraftDimensionKey=y}))