define("@fluentui/react-theme-provider/lib/ThemeContext",["require","exports","react"],(function(n,t,i){"use strict";Object.defineProperty(t,"__esModule",{value:!0});t.ThemeContext=i.createContext(undefined)}));
define("@fluentui/react-theme-provider/lib/useTheme",["require","exports","react","@uifabric/utilities","@fluentui/theme","@fluentui/react-theme-provider/lib/ThemeContext"],(function(n,t,i,r,u,f){"use strict";function e(){return r.useCustomizationSettings(["theme"]).theme}Object.defineProperty(t,"__esModule",{value:!0});t.useTheme=function(){var n=i.useContext(f.ThemeContext),t=e();return n||t||u.createTheme({})}}))