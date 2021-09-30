define("MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/RefreshManager",["require","exports","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/Utils/TelemetryService","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Constants","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Telemetry","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Utilities/ChartUtils","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Utilities/DateUtils","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Utilities/Util"],(function(n,t,i,r,u,f,e,o){"use strict";function l(n){s._instance.registerForRefresh(n)}function a(n){s._instance.unRegisterForRefresh(n)}function v(n,t){s._instance.onTimeContextChange(n,t)}function y(n){s._instance.onRefreshIntervalChange(n)}function h(n){n&&n.intervalToken&&(window.clearInterval(n.intervalToken),n.intervalToken=null)}function p(n){return n?e.dateSpanToSeconds(f.getGrainDateSpanFromTimeContext(n))*500:0}function w(n){return o.GetVisibilityState()===r.VisibilityState.Hidden||n.refreshable.skipRefresh&&n.refreshable.skipRefresh()||!n.refreshable.enableAutoRefresh}var c,s;Object.defineProperty(t,"__esModule",{value:!0});t.RefreshManagerInternal=t.registerForRefresh=t.BaseRefreshable=t.MaximumFailureCount=void 0;t.MaximumFailureCount=5;c=(function(){function n(){this.enableAutoRefresh=!0;this.id=o.GUID();this.refreshIntervalMs=0;this.failureCount=0}return n.prototype.onTimeContextChanged=function(n){v(this,n)},n.prototype.onRefreshIntervalChanged=function(){y(this)},n.prototype.onFailure=function(){s._instance.onFailures(this)},n.prototype.onRefresh=function(n){this.timeContext=n;this.onTimeContextChanged(n);return null},n.prototype.handleRefreshFailure=function(n){n===4||n===6?(this.failureCount++,this.onFailure()):this.failureCount=0},n.prototype.onSkippedRefresh=function(){return},n.prototype.dispose=function(){a(this)},n})();t.BaseRefreshable=c;t.registerForRefresh=l;s=(function(){function n(){this._refreshCache={}}return n.prototype.registerForRefresh=function(n){if(n&&n.id){var t={refreshable:n,lastAutoRefresh:null,intervalToken:null};this._refreshCache[n.id]=t;n.enableAutoRefresh&&this._internalScheduleRefresh(t)}},n.prototype.unRegisterForRefresh=function(n){n&&n.id&&(h(this._refreshCache[n.id]),delete this._refreshCache[n.id])},n.prototype.onManualRefresh=function(n){var t=this;Object.keys(this._refreshCache).forEach((function(i){var r=t._refreshCache[i];if(r&&r.refreshable&&r.refreshable.timeContext){r.refreshable.onRefresh(r.refreshable.timeContext,1,n);r.refreshable.enableAutoRefresh&&t.scheduleRefresh(r.refreshable)}}))},n.prototype.onTimeContextChange=function(n,t){var i=this._getRefreshInfo(n);i&&t!==i.lastAutoRefresh&&this._internalScheduleRefresh(i)},n.prototype.onRefreshIntervalChange=function(n){this._internalScheduleRefresh(this._getRefreshInfo(n))},n.prototype.onFailures=function(n){n.failureCount>=t.MaximumFailureCount&&h(this._getRefreshInfo(n))},n.prototype.scheduleRefresh=function(n){var t=this._getRefreshInfo(n);t&&this._internalScheduleRefresh(t)},n.prototype.cancelRefresh=function(n){var t=this._getRefreshInfo(n);t&&h(t)},n.prototype._isInCache=function(n){return n.id&&!!this._refreshCache[n.id]},n.prototype._getRefreshInfo=function(n){return n.id&&this._refreshCache[n.id]},n.prototype._internalScheduleRefresh=function(n){var f,r,t,e;n&&(f=new u.OperationTelemetry("RefreshManager.internalScheduleRefresh",i.getCommonTelemetryContext()),h(n),r=n.refreshable.timeContext,t=n.refreshable.refreshIntervalMs,t<=0&&r&&(t=p(r)),t>0&&t<Math.pow(2,31)&&(e=window.setInterval((function(){var t=n.refreshable;if(w(n))t.onSkippedRefresh();else if(t.timeContext&&t.timeContext.getIsRelative()){n.lastAutoRefresh=t.timeContext;t.onRefresh(n.lastAutoRefresh,2,f)}}),t),n.intervalToken=e,n.lastAutoRefresh=r))},n._instance=new n,n})();t.RefreshManagerInternal=s}));
define("MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/ViewModels/MetricDataViewModel",["require","exports","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/Strings","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Constants","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/MetricsProvider/MetricsProviderWrapper","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Telemetry","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Utilities/ResourceTypes","MsPortalImpl.Controls/Controls/Visualization/MonitorChartV2/AI/ME/Utilities/Util"],(function(n,t,i,r,u,f,e,o){"use strict";function h(n,t,i,r,e){e===void 0&&(e={});var l=Q.defer(),a=f.AddOperation("MetricDataViewModel.fetchResult",i),v=a.opTimer,y=a.opStop,p=f.PerformanceNow(),s={},h=null,w=e.metricProvider||u.MetricsProviderWrapper.Instance(n.id);return w.fetchMetricResults(n,t,v,e.cause,e.segmentedTopCount,e.ignoreDataPointLimit).then((function(n){s=n;h=s&&Object.keys(s).length>0?{userDataStatus:1}:{userDataStatus:2}})).catch((function(n){h=n&&n.userDataStatus?n:{userDataStatus:4,error:n}})).finally((function(){var i,u;y();i=[];n.metrics&&n.metrics.length>0&&n.metrics.forEach((function(t){var h=o.GetUniqueId(t),u=s&&s[h],e={metricUniqueId:h,metricResults:u&&{aggregation:u.aggregation,data:u.data,startTime:u.startTime,endTime:u.endTime,metricId:u.metricId,timeGrain:u.timeGrain,displayName:u.displayName,timeRangeExtended:u.timeRangeExtended,unit:u.unit},visualization:c(t,u,n.visualization)};!u||u.startTime&&u.endTime||f.logError("The start or end time is null",r,{ContainerName:"fetchControlData",ItemDataModel:JSON.stringify(n),MetricResult:JSON.stringify(u)});e.metricResults&&e.metricResults.aggregation===7&&(e.visualization.unit=1);i.push(e)}));u={chartSeriesData:i,userDataStatusWithError:h,fetchStartTimeStamp:p,timeContext:t};l.resolve(u)})),l.promise}function c(n,t){var u=n.id.resourceDefinition,f,o;e.isResourceDefinition(u)?(f=e.getResourceProvider(u.id),o=u.name||e.getResourceName(u.id)):u&&(f=u.resourceType,o=u.subscription&&(u.subscription.displayName||u.subscription.subscriptionId));var h=!f||!(f.indexOf(r.ResourceTypes.Storage)===0||f.indexOf(r.ResourceTypes.StorageClassic)===0||s[f]),c=n.id.name.displayName||t&&t.displayName||n.id.name.id,l=t&&t.aggregation||n.metricAggregation;return{displayName:c+" ("+i.AggregationDisplayString[l]+")",unit:t&&t.unit||1,displaySIUnit:h,useSIConversions:h&&f!==r.ResourceTypes.SqlServersDatabases,color:n.color,resourceDisplayName:o}}Object.defineProperty(t,"__esModule",{value:!0});t.fetchControlData=void 0;var s={"microsoft.dbformysql/servers":1,"microsoft.dbforpostgresql/servers":1,"microsoft.documentdb/databaseaccounts":1,"microsoft.sql/servers/elasticpools":1,"microsoft.netapp/netappaccounts/capacitypools":1,"microsoft.netapp/netappaccounts/capacitypools/volumes":1,"microsoft.network/networkinterfaces":1,"microsoft.containerregistry/registries":1};t.fetchControlData=h}))