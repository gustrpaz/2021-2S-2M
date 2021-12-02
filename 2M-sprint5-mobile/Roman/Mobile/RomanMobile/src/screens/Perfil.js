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
            <View  style={styles.pagina}>

                <View style={styles.pagTitulo}>
                    <Text style={styles.titulo}>Logout</Text>
                </View>
                <View style={styles.main}>
                    <Image
                        source={require('../assets/coruja.png')}
                        style={styles.corujaLogo}
                    />
                    <TouchableOpacity
                            title="Logout"
                            style={styles.btn}
                            onPress={() => this.realizarlogout()}
                        >
                            <Text style={styles.btnText}>Sair</Text>
                        </TouchableOpacity>
                </View>
            </View>


        )
    };

};

const styles = StyleSheet.create({
    pagina: {
        flex: 1,
        backgroundColor: 'rgba(255, 222, 50, 0.34)',
        alignItems: 'center'
    },
    pagTitulo: {
        width: '40%',
        borderBottomColor: "#009DF5",
        borderBottomWidth: 1,
        alignItems: 'center',
        marginTop: 40
    },

    titulo: {
        textTransform: 'uppercase',
        color: '#009DF5',
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
    corujaLogo: {
        width: '100%',
        height: '90%'
    },
    btn: {
       
    },

    btnText: {
        color: '#009DF5',
        fontWeight: 'bold',
        fontSize: 18
    }
});

export default Perfil;
