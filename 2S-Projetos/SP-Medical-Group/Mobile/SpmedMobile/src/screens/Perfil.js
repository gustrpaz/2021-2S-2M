import React, { Component } from 'react';

import {
    FlatList,
    StyleSheet,
    Text,
    View,
    ScrollView,
    Image,
    TouchableOpacity
} from 'react-native';

import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';

class Perfil extends Component {

    realizarlogout = async () => {
        try {
            await AsyncStorage.removeItem('userToken');
            this.props.navigation.navigate('Login');
        } catch (error) {
            console.warn(error);
        }

    }



    render() {
        return (
            <View style={styles.pagina}>

                <View style={styles.pagTitulo}>
                    <Text style={styles.titulo}>Logout</Text>
                </View>
                <View style={styles.main}>
                    <Image
                        source={require('../assets/logo.png')}
                        style={styles.Logo}
                    />
                    <View style={styles.boxSair}>
                        <TouchableOpacity
                            title="Logout"
                            style={styles.btn}
                            onPress={() => this.realizarlogout()}
                        >
                            <Text style={styles.btnText}>Sair</Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </View>


        )
    };

};

const styles = StyleSheet.create({
    pagina: {
        flex: 1,
        backgroundColor: '#0085FF',
        alignItems: 'center'
    },
    pagTitulo: {
        width: '40%',
        borderBottomColor: "#FFFFFF",
        borderBottomWidth: 3,
        alignItems: 'center',
        marginTop: 40
    },

    titulo: {
        textTransform: 'uppercase',
        color: '#FFFFFF',
        fontWeight: 'bold',
        fontFamily: "Bebas Neue",
        fontSize: 26
    },

    main: {
        flex: 2,
        marginTop: 40,
        width: '100%',
        alignItems: 'center'
    },
    Logo: {
        width: '60%',
        height: '60%'
    },
   
    boxSair: {
        width: 171,
        height: 51.37,
        marginTop:60,
        backgroundColor: '#FFFFFF',
        borderRadius: 10,
        alignItems:'center',
        justifyContent:'center'
    },

    btnText: {
        color: '#009DF5',
        fontWeight: 'bold',
        fontSize: 25
    }
});

export default Perfil;