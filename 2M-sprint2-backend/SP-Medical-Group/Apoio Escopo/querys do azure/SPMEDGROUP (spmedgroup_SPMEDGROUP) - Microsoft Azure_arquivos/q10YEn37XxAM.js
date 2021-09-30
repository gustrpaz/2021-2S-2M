define("MsPortalImpl/Base/Base.Selectable2.Pipeline",["require","exports","Fx/DependencyInjection","MsPortalImpl/Base/Base.Pipeline","MsPortalImpl/Base/Base.Selectable2.Common"],(function(n,t,i,r,u){"use strict";function o(n,t,i,r){var o,u=n.bladeReference,e=n.flags,a=n.operationId,h=u.parameters,c=u.metadata||{},l=n.reason===3,v=s(u,l),f=0;return v||(f|=2),l&&(f|=4),e&2&&(f|=8),e&4&&(f|=128),e&32&&(f|=256),u.disableRebind&&(f|=64),e&8&&(f|=64),{detailBlade:u.bladeName,extension:u.extensionName,detailBladeInputs:h?h:{},openInContextPane:!!(e&1)||c.isContextBlade,persistentContextPane:c.persistentContextPane,flags:f,operationId:a,onClosed:i,telemetryName:n.telemetryName,context:u.context,defaultMenuItemId:u.menuId,contentBladeReference:u.contentBladeReference,notifyBladeOpenCompleted:t,outputs:(o=u.metadata)===null||o===void 0?void 0:o.outputParameters,outputsChanged:r}}function s(n,t){if(t){var i=n.options||{},r=n.metadata||{},u=r.outputParameters||[];return i.onClosed||u.length?!1:!h(n)}return!0}function h(n){var t=f(n);return t&&t.type===20560}Object.defineProperty(t,"__esModule",{value:!0});t.OpenBladeRequestHandler=void 0;var f=FxImpl.shellInterface,e=(function(){function t(n){this._resources=n}return t.prototype.createSelection=function(n,t){var r,e,h;if(!this._resources.selectable.isSelected()){n.indicateTaskComplete();return}var s,i=t.bladeRequest.bladeReference,u=t.bladeRequest.operationId,f=i&&i.options&&i.options.onClosed;f&&u&&(e=this._resources.callbacks,e.push({id:u,fn:f}),s=function(n,t){FxImpl.toPromise(f(n,t)).finally((function(){e.remove((function(n){return n.id===u}))}))});((r=i.options)===null||r===void 0?void 0:r.callbacks)&&(h=function(n){FxImpl.invokeCallback(i,"onOutputsChanged",[n])});t.selection=o(t.bladeRequest,t.notifyBladeOpenCompleted,s,h)},t.prototype.postSelection=function(n,t){this._resources.selectedValue(t.selection)},__decorate([__metadata("fx:diagnostics",[n,"OpenBladeRequestHandler.prototype"]),r.Step(3),__metadata("design:type",Function),__metadata("design:paramtypes",[r.Task,u.OpenBladeTaskArgs]),__metadata("design:returntype",void 0)],t.prototype,"createSelection",null),__decorate([__metadata("fx:diagnostics",[n,"OpenBladeRequestHandler.prototype"]),r.Step(5),__metadata("design:type",Function),__metadata("design:paramtypes",[r.Task,u.OpenBladeTaskArgs]),__metadata("design:returntype",void 0)],t.prototype,"postSelection",null),__decorate([__metadata("fx:diagnostics",[n,"OpenBladeRequestHandler"]),i.Class("pipeline"),__metadata("design:paramtypes",[u.OpenBladeResources])],t)})();t.OpenBladeRequestHandler=e}))