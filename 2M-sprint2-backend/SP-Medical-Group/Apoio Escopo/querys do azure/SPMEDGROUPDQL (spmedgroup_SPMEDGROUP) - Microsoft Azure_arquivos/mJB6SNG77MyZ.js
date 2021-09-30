define("MsPortalImpl/UI/Compositions/UI.Composition.BladeOpener.Selectable2",["require","exports","Fx/DependencyInjection","MsPortalImpl/UI/Compositions/UI.Composition.BladeOpenerBase","MsPortalImpl/Base/Base.Pipeline","MsPortalImpl/Widgets/Widgets.Portal.init"],(function(n,t,i,r,u,f){"use strict";function o(n,t,i,r){var e=i&&i.onClosed,u,f;r&&e&&(u=n.createChildLifetime(),f=function(n,t){t.id===r.id&&(u.dispose(),e(t.reason||1,r.returnValue))},t.customEvents.addHandler(u,"fxbladeclosed",f),t.customEvents.addHandler(u,"fxbladerebound",f))}Object.defineProperty(t,"__esModule",{value:!0});t.SelectableV2Handler=void 0;var e=(function(){function t(n,t,i){this._diContainer=n;this._options=t;this._resources=i}return t.prototype.processExtensionMessages=function(){return Q(this._options.referenceExtension.processMessages())},t.prototype.afterOpenBlade=function(n,t){var e=this._resources,u=t.openedBlades&&t.openedBlades.length===1&&t.openedBlades[0],i=t.value;if(i){var s=i.notifyBladeOpenCompleted,a=i.outputs,h=i.outputsChanged,c=function(){return s(!1)},l=function(){return s(!0)};u?(h&&r.bindOutputsToSelectable2("Selectable2Outputs",e.selectable2,u,a||[],h),u.await(7).then(l,c)):t.reboundBlade?l():c()}o(e.container,f.getPortalViewModel(this._diContainer),i,u||t.reboundBlade)},__decorate([__metadata("fx:diagnostics",[n,"SelectableV2Handler.prototype"]),u.Step(3),__metadata("design:type",Function),__metadata("design:paramtypes",[]),__metadata("design:returntype",void 0)],t.prototype,"processExtensionMessages",null),__decorate([__metadata("fx:diagnostics",[n,"SelectableV2Handler.prototype"]),u.Step(6),__metadata("design:type",Function),__metadata("design:paramtypes",[u.Task,Object]),__metadata("design:returntype",void 0)],t.prototype,"afterOpenBlade",null),__decorate([__metadata("fx:diagnostics",[n,"SelectableV2Handler"]),i.Class("pipeline"),__metadata("design:paramtypes",[i.Container,r.Configuration,r.Resources])],t)})();t.SelectableV2Handler=e}))