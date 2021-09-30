define("office-ui-fabric-react/lib/List",["tslib","react","@uifabric/utilities"],(function(n,t,i){return (function(){"use strict";function r(n){var i=f[n],t;return void 0!==i?i.exports:(t=f[n]={exports:{}},e[n](t,t.exports,r),t.exports)}var e={1867:function(n){n.exports=i},9297:function(n){n.exports=t},4780:function(t){t.exports=n}},f={},u;return r.d=function(n,t){for(var i in t)r.o(t,i)&&!r.o(n,i)&&Object.defineProperty(n,i,{enumerable:!0,get:t[i]})},r.o=function(n,t){return Object.prototype.hasOwnProperty.call(n,t)},r.r=function(n){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(n,Symbol.toStringTag,{value:"Module"});Object.defineProperty(n,"__esModule",{value:!0})},u={},(function(){function s(n,t,i){var r=n.top-t*n.height,u=n.height+(t+i)*n.height;return{top:r,bottom:r+u,height:u,left:n.left,right:n.right,width:n.width}}r.r(u);r.d(u,{List:function(){return l},ScrollToMode:function(){return f}});var n=r(4780),i=r(9297),t=r(1867),f={auto:0,top:1,bottom:2,center:3},e={top:-1,bottom:-1,left:-1,right:-1,width:0,height:0},o=function(n){return n.getBoundingClientRect()},h=o,c=o,l=(function(r){function u(u){var f=r.call(this,u)||this;return f._root=i.createRef(),f._surface=i.createRef(),f._pageRefs={},f._getDerivedStateFromProps=function(n,t){return n.items!==f.props.items||n.renderCount!==f.props.renderCount||n.startIndex!==f.props.startIndex||n.version!==f.props.version?(f._resetRequiredWindows(),f._requiredRect=null,f._measureVersion++,f._invalidatePageCache(),f._updatePages(n,t)):t},f._onRenderRoot=function(t){var r=t.rootRef,u=t.surfaceElement,f=t.divProps;return i.createElement("div",n.__assign({ref:r},f),u)},f._onRenderSurface=function(t){var r=t.surfaceRef,u=t.pageElements,f=t.divProps;return i.createElement("div",n.__assign({ref:r},f),u)},f._onRenderPage=function(t){for(var s=f.props,h=s.onRenderCell,y=s.role,c=t.page,l=c.items,a=void 0===l?[]:l,p=c.startIndex,w=n.__rest(t,["page"]),b=void 0===y?"listitem":"presentation",v=[],r=0;r<a.length;r++){var u=p+r,e=a[r],o=f.props.getKey?f.props.getKey(e,u):e&&e.key;null==o&&(o=u);v.push(i.createElement("div",{role:b,className:"ms-List-cell",key:o,"data-list-index":u,"data-automationid":"ListCell"},h&&h(e,u,f.props.ignoreScrollingState?void 0:f.state.isScrolling)))}return i.createElement("div",n.__assign({},w),v)},t.initializeComponentRef(f),f.state={pages:[],isScrolling:!1,getDerivedStateFromProps:f._getDerivedStateFromProps},f._async=new t.Async(f),f._events=new t.EventGroup(f),f._estimatedPageHeight=0,f._totalEstimates=0,f._requiredWindowsAhead=0,f._requiredWindowsBehind=0,f._measureVersion=0,f._onAsyncScroll=f._async.debounce(f._onAsyncScroll,100,{leading:!1,maxWait:500}),f._onAsyncIdle=f._async.debounce(f._onAsyncIdle,200,{leading:!1}),f._onAsyncResize=f._async.debounce(f._onAsyncResize,16,{leading:!1}),f._onScrollingDone=f._async.debounce(f._onScrollingDone,500,{leading:!1}),f._cachedPageHeights={},f._estimatedPageHeight=0,f._focusedIndex=-1,f._pageCache={},f}return n.__extends(u,r),u.getDerivedStateFromProps=function(n,t){return t.getDerivedStateFromProps(n,t)},Object.defineProperty(u.prototype,"pageRefs",{get:function(){return this._pageRefs},enumerable:!0,configurable:!0}),u.prototype.scrollToIndex=function(n,t,i){var l,y,e;void 0===i&&(i=f.auto);for(var v=this.props.startIndex,p=v+this._getRenderCount(),w=this._allowedRect,r=0,h=1,u=v;u<p;u+=h){if(l=this._getPageSpecification(u,w),y=l.height,h=l.itemCount,u<=n&&u+h>n){if(t&&this._scrollElement){for(var o=c(this._scrollElement),s={top:this._scrollElement.scrollTop,bottom:this._scrollElement.scrollTop+o.height},b=n-u,a=0;a<b;++a)r+=t(u+a);e=r+t(n);switch(i){case f.top:return void(this._scrollElement.scrollTop=r);case f.bottom:return void(this._scrollElement.scrollTop=e-o.height);case f.center:return void(this._scrollElement.scrollTop=(r+e-o.height)/2)}if(r>=s.top&&e<=s.bottom)return;r<s.top||e>s.bottom&&(r=e-o.height)}return void(this._scrollElement.scrollTop=r)}r+=y}},u.prototype.getStartItemIndexInView=function(n){for(var t,i,f,r,u=0,e=this.state.pages||[];u<e.length;u++)if(t=e[u],!t.isSpacer&&(this._scrollTop||0)>=t.top&&(this._scrollTop||0)<=t.top+t.height){if(!n)return i=Math.floor(t.height/t.itemCount),t.startIndex+Math.floor((this._scrollTop-t.top)/i);for(f=0,r=t.startIndex;r<t.startIndex+t.itemCount;r++){if(i=n(r),t.top+f<=this._scrollTop&&this._scrollTop<t.top+f+i)return r;f+=i}}return 0},u.prototype.componentDidMount=function(){this.setState(this._updatePages(this.props,this.state));this._measureVersion++;this._scrollElement=t.findScrollableParent(this._root.current);this._events.on(window,"resize",this._onAsyncResize);this._root.current&&this._events.on(this._root.current,"focus",this._onFocus,!0);this._scrollElement&&(this._events.on(this._scrollElement,"scroll",this._onScroll),this._events.on(this._scrollElement,"scroll",this._onAsyncScroll))},u.prototype.componentDidUpdate=function(n,t){var i=this.props,r=this.state;this.state.pagesVersion!==t.pagesVersion&&(i.getPageHeight?this._onAsyncIdle():this._updatePageMeasurements(r.pages)?(this._materializedRect=null,this._hasCompletedFirstRender?this._onAsyncScroll():(this._hasCompletedFirstRender=!0,this.setState(this._updatePages(i,r)))):this._onAsyncIdle(),i.onPagesUpdated&&i.onPagesUpdated(r.pages))},u.prototype.componentWillUnmount=function(){this._async.dispose();this._events.dispose();delete this._scrollElement},u.prototype.shouldComponentUpdate=function(n,t){var r=this.state.pages,o=t.pages,u=!1,i,f,e;if(!t.isScrolling&&this.state.isScrolling||n.version!==this.props.version)return!0;if(n.items===this.props.items&&r.length===o.length){for(i=0;i<r.length;i++)if(f=r[i],e=o[i],f.key!==e.key||f.itemCount!==e.itemCount){u=!0;break}}else u=!0;return u},u.prototype.forceUpdate=function(){this._invalidatePageCache();this._updateRenderRects(this.props,this.state,!0);this.setState(this._updatePages(this.props,this.state));this._measureVersion++;r.prototype.forceUpdate.call(this)},u.prototype.getTotalListHeight=function(){return this._surfaceRect.height},u.prototype.render=function(){for(var l,a,i=this.props,v=i.className,e=i.role,y=void 0===e?"list":e,o=i.onRenderSurface,s=i.onRenderRoot,h=this.state.pages,r=void 0===h?[]:h,u=[],p=t.getNativeProps(this.props,t.divProperties),f=0,c=r;f<c.length;f++)l=c[f],u.push(this._renderPage(l));return a=o?t.composeRenderFunction(o,this._onRenderSurface):this._onRenderSurface,(s?t.composeRenderFunction(s,this._onRenderRoot):this._onRenderRoot)({rootRef:this._root,pages:r,surfaceElement:a({surfaceRef:this._surface,pages:r,pageElements:u,divProps:{role:"presentation",className:"ms-List-surface"}}),divProps:n.__assign(n.__assign({},p),{className:t.css("ms-List",v),role:u.length>0?y:void 0})})},u.prototype._shouldVirtualize=function(n){void 0===n&&(n=this.props);var t=n.onShouldVirtualize;return!t||t(n)},u.prototype._invalidatePageCache=function(){this._pageCache={}},u.prototype._renderPage=function(n){var t,f=this,i=this.props.usePageCache;if(i&&(t=this._pageCache[n.key])&&t.pageElement)return t.pageElement;var e=this._getPageStyle(n),r=this.props.onRenderPage,u=(void 0===r?this._onRenderPage:r)({page:n,className:"ms-List-page",key:n.key,ref:function(t){f._pageRefs[n.key]=t},style:e,role:"presentation"},this._onRenderPage);return i&&0===n.startIndex&&(this._pageCache[n.key]={page:n,pageElement:u}),u},u.prototype._getPageStyle=function(t){var i=this.props.getPageStyle;return n.__assign(n.__assign({},i?i(t):{}),t.items?{}:{height:t.height})},u.prototype._onFocus=function(n){for(var r,i=n.target;i!==this._surface.current;){if(r=i.getAttribute("data-list-index"),r){this._focusedIndex=Number(r);break}i=t.getParent(i)}},u.prototype._onScroll=function(){this.state.isScrolling||this.props.ignoreScrollingState||this.setState({isScrolling:!0});this._resetRequiredWindows();this._onScrollingDone()},u.prototype._resetRequiredWindows=function(){this._requiredWindowsAhead=0;this._requiredWindowsBehind=0},u.prototype._onAsyncScroll=function(){var n,t;this._updateRenderRects(this.props,this.state);this._materializedRect&&(n=this._requiredRect,t=this._materializedRect,n.top>=t.top&&n.left>=t.left&&n.bottom<=t.bottom&&n.right<=t.right)||this.setState(this._updatePages(this.props,this.state))},u.prototype._onAsyncIdle=function(){var i=this.props,r=i.renderedWindowsAhead,u=i.renderedWindowsBehind,f=this._requiredWindowsAhead,e=this._requiredWindowsBehind,n=Math.min(r,f+1),t=Math.min(u,e+1);n===f&&t===e||(this._requiredWindowsAhead=n,this._requiredWindowsBehind=t,this._updateRenderRects(this.props,this.state),this.setState(this._updatePages(this.props,this.state)));(r>n||u>t)&&this._onAsyncIdle()},u.prototype._onScrollingDone=function(){this.props.ignoreScrollingState||this.setState({isScrolling:!1})},u.prototype._onAsyncResize=function(){this.forceUpdate()},u.prototype._updatePages=function(t,i){this._requiredRect||this._updateRenderRects(t,i);var r=this._buildPages(t,i),u=i.pages;return this._notifyPageChanges(u,r.pages,this.props),n.__assign(n.__assign(n.__assign({},i),r),{pagesVersion:{}})},u.prototype._notifyPageChanges=function(n,t,i){var c=i.onPageAdded,l=i.onPageRemoved,f,o,r,s;if(c||l){for(var u={},e=0,h=n;e<h.length;e++)(r=h[e]).items&&(u[r.startIndex]=r);for(f=0,o=t;f<o.length;f++)(r=o[f]).items&&(u[r.startIndex]?delete u[r.startIndex]:this._onPageAdded(r));for(s in u)u.hasOwnProperty(s)&&this._onPageRemoved(u[s])}},u.prototype._updatePageMeasurements=function(n){var t=!1,i,r;if(!this._shouldVirtualize())return t;for(i=0;i<n.length;i++)r=n[i],r.items&&(t=this._measurePage(r)||t);return t},u.prototype._measurePage=function(n){var r=!1,i=this._pageRefs[n.key],u=this._cachedPageHeights[n.startIndex],t;return i&&this._shouldVirtualize()&&(!u||u.measureVersion!==this._measureVersion)&&(t={width:i.clientWidth,height:i.clientHeight},(t.height||t.width)&&(r=n.height!==t.height,n.height=t.height,this._cachedPageHeights[n.startIndex]={height:t.height,measureVersion:this._measureVersion},this._estimatedPageHeight=Math.round((this._estimatedPageHeight*this._totalEstimates+t.height)/(this._totalEstimates+1)),this._totalEstimates++)),r},u.prototype._onPageAdded=function(n){var t=this.props.onPageAdded;t&&t(n)},u.prototype._onPageRemoved=function(n){var t=this.props.onPageRemoved;t&&t(n)},u.prototype._buildPages=function(i,r){var v=i.renderCount,d=i.items,l=i.startIndex,g=i.getPageHeight;v=this._getRenderCount(i);for(var y=n.__assign({},e),c=[],h=1,o=0,u=null,p=this._focusedIndex,w=l+v,b=this._shouldVirtualize(i),k=0===this._estimatedPageHeight&&!g,s=this._allowedRect,nt=function(n){var g=f._getPageSpecification(n,s),nt=g.height,tt=g.data,ut=g.key,rt,v;h=g.itemCount;var i,e,a=o+nt-1,ft=t.findIndex(r.pages,(function(t){return!!t.items&&t.startIndex===n}))>-1,et=!s||a>=s.top&&o<=s.bottom,it=!f._requiredRect||a>=f._requiredRect.top&&o<=f._requiredRect.bottom;return!k&&(it||et&&ft)||!b||p>=n&&p<n+h||n===l?(u&&(c.push(u),u=null),rt=Math.min(h,w-n),v=f._createPage(ut,d.slice(n,n+rt),n,void 0,void 0,tt),v.top=o,v.height=nt,f._visibleRect&&f._visibleRect.bottom&&(v.isVisible=a>=f._visibleRect.top&&o<=f._visibleRect.bottom),c.push(v),it&&f._allowedRect&&(i=y,e={top:o,bottom:a,height:nt,left:s.left,right:s.right,width:s.width},i.top=e.top<i.top||-1===i.top?e.top:i.top,i.left=e.left<i.left||-1===i.left?e.left:i.left,i.bottom=e.bottom>i.bottom||-1===i.bottom?e.bottom:i.bottom,i.right=e.right>i.right||-1===i.right?e.right:i.right,i.width=i.right-i.left+1,i.height=i.bottom-i.top+1)):(u||(u=f._createPage("spacer-"+n,void 0,n,0,void 0,tt,!0)),u.height=(u.height||0)+(a-o)+1,u.itemCount+=h),(o+=a-o+1,k&&b)?"break":void 0},f=this,a=l;a<w&&"break"!==nt(a);a+=h);return u&&(u.key="spacer-end",c.push(u)),this._materializedRect=y,n.__assign(n.__assign({},r),{pages:c,measureVersion:this._measureVersion})},u.prototype._getPageSpecification=function(n,t){var u=this.props.getPageSpecification;if(u){var i=u(n,t),f=i.itemCount,r=void 0===f?this._getItemCountForPage(n,t):f,e=i.height;return{itemCount:r,height:void 0===e?this._getPageHeight(n,t,r):e,data:i.data,key:i.key}}return{itemCount:r=this._getItemCountForPage(n,t),height:this._getPageHeight(n,t,r)}},u.prototype._getPageHeight=function(n,t,i){if(this.props.getPageHeight)return this.props.getPageHeight(n,t,i);var r=this._cachedPageHeights[n];return r?r.height:this._estimatedPageHeight||30},u.prototype._getItemCountForPage=function(n,t){return(this.props.getItemCountForPage?this.props.getItemCountForPage(n,t):10)||10},u.prototype._createPage=function(n,t,i,r,u,f,e){void 0===i&&(i=-1);void 0===r&&(r=t?t.length:0);void 0===u&&(u={});n=n||"page-"+i;var o=this._pageCache[n];return o&&o.page?o.page:{key:n,startIndex:i,itemCount:r,items:t,style:u,top:0,height:0,data:f,isSpacer:e||!1}},u.prototype._getRenderCount=function(n){var t=n||this.props,i=t.items,u=t.startIndex,r=t.renderCount;return void 0===r?i?i.length-u:0:r},u.prototype._updateRenderRects=function(i,r,u){var y=i.renderedWindowsAhead,p=i.renderedWindowsBehind,w=r.pages;if(this._shouldVirtualize(i)){var f=this._surfaceRect||n.__assign({},e),o=this._scrollElement&&this._scrollElement.scrollHeight,l=this._scrollElement?this._scrollElement.scrollTop:0;this._surface.current&&(u||!w||!this._surfaceRect||!o||o!==this._scrollHeight||Math.abs(this._scrollTop-l)>this._estimatedPageHeight/3)&&(f=this._surfaceRect=h(this._surface.current),this._scrollTop=l);!u&&o&&o===this._scrollHeight||this._measureVersion++;this._scrollHeight=o;var a=Math.max(0,-f.top),v=t.getWindow(this._root.current),c={top:a,left:f.left,bottom:a+v.innerHeight,right:f.right,width:f.width,height:v.innerHeight};this._requiredRect=s(c,this._requiredWindowsBehind,this._requiredWindowsAhead);this._allowedRect=s(c,p,y);this._visibleRect=c}},u.defaultProps={startIndex:0,onRenderCell:function(n){return i.createElement(i.Fragment,null,n&&n.name||"")},renderedWindowsAhead:2,renderedWindowsBehind:2},u})(i.Component)})(),u})()}))