define("MsPortalImpl/Widgets/ServiceHoverCard",["require","exports","MsPortalImpl/TsxStringMode/Tsx","MsPortalImpl/TsxStringMode/Tsx","Fx/Controls/Toolbar","MsPortalImpl/Resources/ImplScriptResources","FxHubs/RpcEndPoints","MsPortalImpl/Services/Services.BrowseCuration","FxHubs/ResourceCommands/BrowseCommanding","MsPortalImpl/UI/UI.BladeOpener","MsPortalImpl/UI/Hubs/UI.FavoritesManagerDeferred","MsPortalImpl/UI/Hubs/UI.FavoritesManager","FxHubs/RpcEndPoints","MsPortalImpl/Services/Services.AssetTypes","Fx/Composition/Selectable","MsPortalImpl/Widgets/Widgets.HoverCard"],(function(n,t,i,r,u,f,e,o,s,h,c,l,a,v,y,p){"use strict";function k(n){MsPortalFx.require("MsPortalImpl/Widgets/Widgets.SideBarFlyout").then((function(t){var i=n.diContainer.get(l.FavoritesManager);t.toggleFavorite(n.favorite,n.diContainer.get(l.FavoritesManager),n.diContainer.get(c.FavoritesManagerDeferred));i.loadFavorites()}))}function ft(n,t,i,r){var f=n.id,o=t&&t[f]||{},u=n.assetType.assetTypeManifest,h,c,e,s;return n.kind&&n.assetType.kindMap&&(u=n.assetType.kindMap[n.kind.toLowerCase()]||u),f==="HubsExtension_BrowseAllResources"&&(u.marketplaceItemId="hub"),u.marketplaceItemId?h="#create/"+u.marketplaceItemId:u.noPdlCreateBlade&&(c=new y.ProvisioningBladeReference(u.noPdlCreateBlade,u.noPdlCreateExtension)),e=ko.observable(),f.toLowerCase()===v.lowerCaseAllResourcesId?e(v.getBrowseAllDeeplink()):v.getBrowseBladeUri(i,f.toLowerCase()).then((function(t){return e(t||n.uri)})),s=ko.observableArray(),Q.all([MsPortalFx.require("MsPortalImpl/UI/UI.DeepLink"),a.AssetTypes.getRecentResourcesEndPoint.invoke(i.get(FxImpl.Rpc.Client),MsPortalFx.Base.Constants.ExtensionNames.Hubs,{limit:3,assetTypeId:f==="HubsExtension_BrowseAllResources"?undefined:f})]).spread((function(n,t){s(t.map((function(t){var r=t.resourceId,u=t.timeStamp,f=t.name,e=t.assetTypeInformation.icon,o=new Date(u).toRelativeString("difference");return{resourceId:n.getResourceDeepLink(i,r),timeStamp:o,icon:e,name:f}})))})),{recentClick:function(t){return p.logTelemetry("BrowseRecentResourceLinkClicked",n.id,{resourceName:t.name,resourceId:t.resourceId,source:r}),!0},usefulClick:function(t){return p.logTelemetry("UsefulResourceLinkClicked",n.id,{linkDestination:t.link,displayTitle:t.linkTitle,source:r}),!0},trainingClick:function(t){return p.logTelemetry("TrainingLinkClicked",n.id,{linkDestination:t.link,displayTitle:t.title,source:r}),!0},freeClick:function(t){return p.logTelemetry("FreeOfferingLinkClicked",n.id,{linkDestination:t.createUri,displayTitle:t.title,source:r}),!0},createLink:h,createBladeReference:c,deepLink:e,description:u.description,freeOfferings:o.freeOfferings,recents:s,trainings:o.trainings,usefulLinks:o.usefulLinks}}var d,g;Object.defineProperty(t,"__esModule",{value:!0});t.ViewModel=void 0;var b=u.ToolbarItems.createBasicButton,nt=MsPortalFx.Base,w=nt.Images,tt=FxImpl.TriggerableLifetimeManager,it="fxs-hover-card-description",rt=18,ut=5;d=(function(n){function t(t,i,r,c){var a=n.call(this)||this;return a.onClickToggleExpandedState=function(){a.isDescriptionExpanded(!a.isDescriptionExpanded())},a.additionalInfo=ko.observable(),a.possibleFavorite=ko.observable(),a.favoriteInitial=null,a.addIcon=w.Add({palette:3}),a.viewIcon=w.View({palette:3}),a.favoriteIcon=w.Star({palette:99}),a.notFavoriteIcon=w.Favorite({palette:99}),a.isDescriptionExpanded=ko.observable(!1),a.seeMoreString=ko.pureComputed((function(){return a.isDescriptionExpanded()?f.ServicesInfo.HoverCard.seeLess:f.ServicesInfo.HoverCard.seeMore})),a.expandIcon=w.CaretDown(),a.toolbar=ko.observable(),a.lifetime=new tt,a.template=g,a.dockingElement=i,a.focusContent=a.additionalInfo,a._hoverCardSource=c,a.possibleFavorite(t),a.onFavoritesChange=function(n){var t=MsPortalFx.find(n,(function(n){return n&&n.id===a.possibleFavorite().id}));t&&a.possibleFavorite(t)},a.setFavorite=function(){if(a.favoriteOnDismiss){a.updateFavorite=function(){var n=a.possibleFavorite(),t=n.isFavorite(),i=r.get(l.FavoritesManager),u=!!i.favorites.value.find((function(t){return t.id===n.id}));t!==u&&(n.isFavorite=ko.observable(!t),k({favorite:n,diContainer:r}))};var n=a.possibleFavorite();n.isFavorite(!n.isFavorite())}else k({favorite:a.possibleFavorite(),diContainer:r})},a.shouldShowExpandButton=function(n){var t=$(n.parentNode).findByClassName(it)[0];return t.scrollHeight>rt*ut},a._bladeManagement={openBlade:function(n){return r.get(h.BladeOpener).openBlade(n,{flags:8,telemetryName:"ServiceHoverCard"})},openContextPane:function(n){return r.get(h.BladeOpener).openBlade(n,{flags:9,telemetryName:"ServiceHoverCard"})},openBladeAsync:function(){return Promise.resolve(!1)},openContextPaneAsync:function(){return Promise.resolve(!1)}},o.getAllServicesAdditionalData().then((function(n){var t,i;a.additionalInfo(ft(a.possibleFavorite(),n.assetTypesDataMap,r,a._hoverCardSource));e.ArtBrowse.getBrowsePrereqsEndpoint.invoke(FxImpl.Rpc.client,"fxw",{resourceType:(i=(t=a.possibleFavorite())===null||t===void 0?void 0:t.assetType)===null||i===void 0?void 0:i.lowerCaseResourceType,includeColumnsVersion:2}).then((function(n){return __awaiter(a,void 0,void 0,(function(){var e,i,t=this,o,c,l,a;return __generator(this,(function(){return e=s.createServiceHoverCardCommand("ServiceHoverCard-"+this._hoverCardSource,n===null||n===void 0?void 0:n.browseQueryManifest,this.lifetime,(function(){var n,i;if((i=(n=t.possibleFavorite())===null||n===void 0?void 0:n.assetType)!==null&&i!==void 0)return i.extension}),(o=this.possibleFavorite())===null||o===void 0?void 0:o.resourceType,this._bladeManagement),i=[],e?i.push(e):(((c=this.additionalInfo())===null||c===void 0?void 0:c.createLink)||((l=this.additionalInfo())===null||l===void 0?void 0:l.createBladeReference))&&i.push(b(this.lifetime,{label:f.ActionBarButtons.create,icon:this.addIcon,onClick:function(){p.logTelemetry("CreateResourceLinkClicked",t.possibleFavorite().id,{source:t._hoverCardSource});t.additionalInfo().createLink?window.location.hash=t.additionalInfo().createLink:r.get(h.BladeOpener).openBlade(t.additionalInfo().createBladeReference,{flags:2,telemetryName:"ServiceHoverCard"});t.widget.dispose()}})),((a=this.additionalInfo())===null||a===void 0?void 0:a.deepLink)&&i.push(b(this.lifetime,{label:f.ActionBarButtons.view,icon:this.viewIcon,onClick:function(){p.logTelemetry("ViewResourceLinkClicked",t.possibleFavorite().id,{source:t._hoverCardSource});window.location.hash=t.additionalInfo().deepLink()}})),this.toolbar(u.create(this.lifetime,{items:i,showLabels:!0})),[2]}))}))}))})),a}return __extends(t,n),t})(p.ViewModel);t.ViewModel=d;g=i(r.Root,null,i("div",{"class":"fxs-hover-card-container fxs-portal-background fxs-portal-text"},i("div",{"class":"fxs-hide-accessible-label",id:"hoverCardDescriptionId",title:f.ServicesInfo.showServiceCard,"aria-hidden":"true"},f.ServicesInfo.showServiceCard),i("div",{"class":"fxs-hover-card-initial","data-bind":{css:{"fxs-hover-card-padbottom":"!additionalInfo()"}}},i("div",{"class":"fxs-hover-card-header"},i("div",{"class":"fxs-hover-card-icon","data-bind":{image:"possibleFavorite().icon || possibleFavorite().image"}}),i("header",{"class":"fxs-hover-card-title","data-bind":{text:"possibleFavorite().label",attr:{title:"possibleFavorite().label"}}}),i(r.KoIf,{condition:"additionalInfo()"},i("div",{"class":"fxs-hover-card-favoriteicon",role:"button","aria-pressed":"false","aria-label":f.KeyboardShortcuts.Toggle.toggleFavoriteService,"data-bind":{fxclick:"setFavorite",image:"possibleFavorite().isFavorite() ? favoriteIcon : notFavoriteIcon"}}))),i("div",{"class":"fxs-hover-card-commands"},i("div",{"data-bind":{pcControl:"toolbar"}}))),i(r.KoIf,{condition:"additionalInfo()"},i("div",{"class":"fxs-hover-card-border"}),i("div",{"class":"fxs-hover-card"},i("div",{"class":"fxs-hover-card-additional","data-bind":{"with":"additionalInfo"}},i(r.KoIf,{condition:"recents"},i(r.KoIf,{condition:"recents().length"},i("div",{"class":"fxs-hover-card-padless-header"},i("header",{"class":"fxs-hover-card-heading"},f.ServicesInfo.HoverCard.Header.recents)),i("ul",{"class":"fxs-hover-card-training fxs-hover-card-list fxs-hover-card-padbottom","data-bind":{foreach:"recents"}},i("li",{"class":"fxs-hover-card-list-item"},i("div",{"class":"fxs-hover-card-training-item fxs-portal-hover"},i("div",{"class":"fxs-hover-card-training-icon","data-bind":{image:"$data.icon"}}),i("div",{"class":"fxs-hover-card-training-link"},i("a",{"class":"fxs-hover-card-training-link",href:"","data-bind":{click:"$parent.recentClick",text:"$data.name",attr:{title:"$data.name",href:"$data.resourceId"}}}),i("div",{"class":"fxs-hover-card-training-sub"},i("span",{"data-bind":{text:"$data.timeStamp"}}))))))),i(r.KoIfNot,{condition:"recents().length"},i(r.KoIf,{condition:"description"},i("div",{"class":"fxs-hover-card-section"},i("header",{"class":"fxs-hover-card-heading"},f.ServicesInfo.HoverCard.Header.description),i("div",{"data-bind":{text:"description",css:{"fxs-hover-card-description":"true","fxs-hover-card-expanded-description":"$parent.isDescriptionExpanded()"}}}),i(r.KoIf,{condition:"$parent.shouldShowExpandButton($element)"},i("a",{href:"#","class":"fxs-hover-card-seemore-link",tabindex:"0","data-bind":{click:"$parent.onClickToggleExpandedState",clickBubble:"false"}},i("div",{"class":"fxs-hover-card-see-more-less","data-bind":{text:"$parent.seeMoreString",attr:{title:"$parent.seeMoreString",ariaLabel:"$parent.seeMoreString"}}}),i("div",{"data-bind":{image:"$parent.expandIcon",css:{"fxs-hover-card-expand-icon":"true","fxs-hover-card-icon-vertical-transform":"$parent.isDescriptionExpanded()"}}}))))))),i(r.KoIf,{condition:"trainings && trainings.length"},i("div",{"class":"fxs-hover-card-padless-header"},i("header",{"class":"fxs-hover-card-heading"},f.ServicesInfo.HoverCard.Header.training)),i("ul",{"class":"fxs-hover-card-training fxs-hover-card-list fxs-hover-card-padbottom","data-bind":{foreach:"trainings"}},i("li",{"class":"fxs-hover-card-list-item"},i("div",{"class":"fxs-hover-card-training-item fxs-portal-hover"},i("div",{"class":"fxs-hover-card-training-link"},i("a",{"class":"msportalfx-ext-link",href:"",target:"_blank","data-bind":{click:"$parent.trainingClick",text:"$data.title",attr:{title:"$data.title",href:"$data.link"}}}),i("div",{"class":"fxs-hover-card-training-sub"},i("span",{"data-bind":{text:"$data.units"}}),i(r.KoIf,{condition:"$data.units && $data.duration"},i("span",null," · ")),i("span",{"data-bind":{text:"$data.duration"}}))))))),i(r.KoIf,{condition:"usefulLinks && usefulLinks.length"},i("div",{"class":"fxs-hover-card-section fxs-hover-card-padleftright"},i("header",{"class":"fxs-hover-card-heading"},f.ServicesInfo.HoverCard.Header.usefulLinks),i("ul",{"class":"fxs-hover-card-list","data-bind":{foreach:"usefulLinks"}},i("li",{"class":"fxs-hover-card-list-item"},i("a",{target:"_blank","data-bind":{click:"$parent.usefulClick",text:"$data.title",attr:{href:"$data.link"},css:{"msportalfx-ext-link":"$data.isExternalLink"}}}))))),i(r.KoIf,{condition:"freeOfferings && freeOfferings.length"},i("div",{"class":"fxs-hover-card-padless-header"},i("header",{"class":"fxs-hover-card-heading"},f.ServicesInfo.HoverCard.Header.freeOfferings)),i("ul",{"class":"fxs-hover-card-training fxs-hover-card-list fxs-hover-card-padbottom","data-bind":{foreach:"freeOfferings"}},i("li",{"class":"fxs-hover-card-list-item"},i("div",{"class":"fxs-hover-card-training-item fxs-portal-hover"},i("div",{"class":"fxs-hover-card-training-link"},i("a",{"class":"fxs-hover-card-training-link",href:"","data-bind":{click:"$parent.freeClick",text:"$data.title",attr:{href:"$data.createUri"}}}),i("div",{"class":"fxs-hover-card-training-sub"},i("span",{"data-bind":{text:"$data.subTitle"}}))))))))))))}))