import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Image,
  ImageBackground,
  TextInput,
  ImageBase,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
    };
  }
  //como vamos trabalhar com assync storage,
  //nossa funcao tem que ser async.
  realizarLogin = async () => {
    
    const resposta = await api.post('/login', {
      email: this.state.email,
      senha: this.state.senha,
    });

    //mostrar no swagger para montar.
    const token = resposta.data.token;
    await AsyncStorage.setItem('userToken', token);

    if (resposta.status == 200) {
      this.props.navigation.navigate('Main');
    }

  };

  render() {
    return (

      <View style={styles.CorpoLogin}>

        <Image
          source={require('../assets/logo_branca.png')}
          style={styles.ImgLogin}
        />
        
        <View style={styles.CorpoEmail}>

          <TextInput
            style={styles.inputEmail}
            placeholder="EMAIL"
            placeholderTextColor="#A4A4A4"
            keyboardType="email-address"
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={email => this.setState({ email })}
          />

          <TextInput
            style={styles.inputSenha}
            placeholder="SENHA"
            placeholderTextColor="#A4A4A4"
            keyboardType="default" //para default nao obrigatorio.
            secureTextEntry={true} //proteje a senha.
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={senha => this.setState({ senha })}
          />

          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.realizarLogin}>
            <Text style={styles.Entrar}>Login</Text>
          </TouchableOpacity>
        </View>

      </View>

    );
  }
}

const styles = StyleSheet.create({

    TituloLogin: {
      color: '#009DF5',
      fontSize: 37,
      fontFamily: 'BebasNeue-Regular',
    },
  

    inputEmail: {
      width: 304,
      height: 54,
      backgroundColor: 'white',
      borderRadius: 20,
      borderColor: '#009DF5',
      borderWidth: 2,
      paddingLeft:20,
      marginTop: 38,
  
  
    },
    inputSenha: {
      width: 304,
      height: 54,
      backgroundColor: 'white',
      color: '#A4A4A4',
      borderRadius: 20,
      borderColor: '#009DF5',
      borderWidth: 2,
      paddingLeft:20,
      marginTop: 38,
    },
  
    btnLogin: {
      height: 52,
      width: 134,
      borderColor:'#009DF5',
      borderWidth:2,
      borderRadius: 20,
      backgroundColor: 'white',
      marginTop:50,
      display:'flex',
      alignItems: 'center',
  
    },
  
    ImgLogin: {
        marginTop: 50,
    },
  
  
    CorpoLogin: {
      flex: 1,
      height: '100%',
      backgroundColor: '#0085FF',
      display: 'flex',
      alignItems: 'center',
      
  
    },
  
    CorpoEmail: {
      marginTop: 80,
      borderWidth: 3,
      borderColor: 'white',
      borderRadius: 20,
      height: 334,
      width: 353,
      // flex: 1,
      display: 'flex',
      alignItems: 'center',
      marginBottom: 30,
    },
  
    Entrar:{
      color:'#009DF5',
      marginTop:13,
      fontSize: 20,
      
    }
  
  },
  );