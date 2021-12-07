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
                    <View style={styles.box_user}>
                        <Image
                            source={require('../assets/user-solid.png')}
                            style={styles.Logo}
                        />
                    </View>
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
        width: '30%',
        borderBottomColor: "#FFFFFF",
        borderBottomWidth: 3,
        alignItems: 'center',
        marginTop: 50
    },

    titulo: {
        color: '#FFFFFF',
        fontFamily: "BebasNeue-Regular",
        fontSize: 40
    },

    main: {
        flex: 2,
        marginTop: 40,
        width: '100%',
        alignItems: 'center'
    },

    Logo: {
        width: 200,
        height: 300,
        marginTop: 10,
    },

    boxSair: {
        width: 171,
        height: 51.37,
        marginTop: 40,
        backgroundColor: '#FFFFFF',
        borderRadius: 10,
        alignItems: 'center',
        justifyContent: 'center'
    },

    btnText: {
        color: '#009DF5',
        fontSize: 30,
        fontFamily: 'TitilliumWeb-Light'
    }
});

export default Perfil;