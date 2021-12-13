import React, { Component } from 'react';
import {
  Image,
  StatusBar,
  StyleSheet,
  View,
} from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';


const bottomTab = createBottomTabNavigator();

import Consultas from './Consultas';
import Perfil from './Perfil';

class Main extends Component {

  render(){
    return (
      <View style={styles.main}>
        <StatusBar 
          hidden={false}
        />

          <bottomTab.Navigator
            initialRouteName='Consultas'
            
            screenOptions={ ({ route }) => ({
              tabBarIcon: () => {
                if (route.name === 'Consultas') {
                  return(
                    <Image
                      source={require('../assets/clipboard-list-solid.png')}
                      style={styles.tabBarIconL}
                    />
                  )
                }
                if (route.name === 'Perfil') {
                  return(
                    <Image
                      source={require('../assets/sign-out-alt-solid.png')}
                      style={styles.tabBarIconS}
                    />
                  )
                }
              },

              // React Navigation 6.x
              headerShown: false,
              tabBarShowLabel: false,
              tabBarActiveBackgroundColor: '#68c2e8',
              tabBarInactiveBackgroundColor: '#009df5',
              // tabBarActiveTintColor: 'blue',
              // tabBarInactiveTintColor: 'red',
              tabBarStyle: { height: 80 },
                         
            }) }
          >
            <bottomTab.Screen name="Consultas" component={Consultas} />
            <bottomTab.Screen name="Perfil" component={Perfil} />
          </bottomTab.Navigator>        

      </View>
    );
  }
  
};

const styles = StyleSheet.create({

  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  },

  // estilo dos ícones da tabBar
  tabBarIconL: {
    width: 41,
    height: 54,   
  },

  tabBarIconP: {
    width: 45,
    height: 46   
  },

  tabBarIconS: {
    width: 55,
    height: 46   
  }

});

export default Main;