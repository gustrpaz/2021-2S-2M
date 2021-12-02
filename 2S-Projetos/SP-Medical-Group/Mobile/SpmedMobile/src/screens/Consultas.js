import { CurrentRenderContext } from '@react-navigation/core';
import React, { Component } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../services/api';

import {
    FlatList,
    StyleSheet,
    Text,
    View,
    Image,
    ScrollView
} from 'react-native';

class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: []
        };
    };

    // Define a função que faz a chamada pra api e traz os projetos 
    buscarProjetos = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');

            const resposta = await api.get('/consultas/minhasmed', {
                headers: {
                    Authorization: 'Bearer ' + token,
                },
            });
            if (resposta.status === 200) {
                console.warn('chegou')
                const dadosDaApi = resposta.data;
                this.setState({ listaConsultas: dadosDaApi });
                console.warn(this.state.listaConsultas)
            }
        } catch (error) {
            console.warn(error);
        }
    };


    componentDidMount() {
        this.buscarProjetos();
    }

    render() {
        return (


            <View style={styles.bodyConsulta}>
                {/* Cabeçalho - Header */}
                <View style={styles.container_logo}>
                    <Image
                        source={require('../assets/logo.png')}
                        style={styles.Logo}
                    />
                </View>

                <View style={styles.mainHeader}>

                    <View style={styles.pagTitulo}>
                        <Text style={styles.titulo}>Consultas</Text>
                    </View>


                </View>

               


                {/* Corpo - Body */}
                <View style={styles.mainBody}>
                    <FlatList
                        // contentContainerStyle={styles.mainBodyContent}
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderItem}
                    />
                </View>
            </View>
        )
    };

    renderItem = ({ item }) => (
        <View style={styles.cardConsulta}>
            <View style={styles.flatItemRow}>
                <View style={styles.flatItemContainer}>
                    <Text style={styles.flatItemTitle}>{(item.idPaciente)}</Text>
                    <View style={styles.containerCard}>
                        <View style={styles.box_descricao}>
                            {/* <Text style={styles.descricao}>{item.descricao}</Text> */}
                        </View>


                    </View>

                </View>
            </View>
        </View>
    )
};

const styles = StyleSheet.create({


    cardConsulta: {
        width: 384,
        height: 300,
        backgroundColor: '#FFFFFF',
        borderRadius: 10,
        marginBottom: 20,
    },


    // ------------------------------

    pagTitulo: {
        width: '40%',
        height: 40,
        borderBottomColor: "#FFFFFF",
        borderBottomWidth: 3,
        alignItems: 'center'
    },

    titulo: {
        textTransform: 'uppercase',
        color: '#FFFFFF',
        fontWeight: 'bold',
        fontFamily: "Bebas Neue",
        fontSize: 26,

    },

    container_logo: {
        height: 125,
        width: 125,
        justifyContent: 'center',
        marginTop: 35
    },

    Logo: {
        width: 117,
        height: 125,
    },

    bodyConsulta: {
        height: '100%',
        backgroundColor: '#0085FF',
        alignItems: 'center'
    },

    mainBody: {
        flex: 4,
    },

    cardProjeto: {
        width: 390,
        borderRadius: 20,
        marginTop: 20,
        marginBottom: 20,
        backgroundColor: '#3DB0F0',
    },

    containerCard: {
        width: '100%',
        alignItems: 'center',
        justifyContent: 'space-around',
        flexDirection: 'row',

        // backgroundColor: 'green',
    },

    container_titulo: {
        width: 165,
        alignItems: 'center',
        borderBottomColor: '#009DF5',
        borderBottomWidth: 2,
        marginBottom: 20,
    },

    txtTitulo: {
        fontSize: 37,
        color: '#009DF5',
        
    },
    // conteúdo da lista
    main: {
        flex: 1,
        backgroundColor: '#F1F1F1',
    },
    // cabeçalho
    mainHeader: {
        flex: 0.8,
        justifyContent: 'center',
        alignItems: 'center',
    },

    mainHeaderRow: {
        flexDirection: 'row',
    },

    // conteúdo do body
    mainBody: {
        flex: 3,
    },
    // conteúdo da lista
    mainBodyContent: {
        width: 430,
        paddingTop: 10,
        paddingRight: 10,
        paddingLeft: 10,
    },
    // dados do evento de cada item da lista (ou seja, cada linha da lista)
    flatItemRow: {
        flexDirection: 'row',
    },
    flatItemContainer: {
        flex: 1,
    },
    flatItemTitle: {
        fontSize: 27,
        color: '#000000',
        marginLeft: 15,
    },

    boxLapis: {
        width: 160,
        height: 110,
        alignItems: 'center',

        // backgroundColor: 'blue',
    },

    lapis: {
        width: 70,
        height: 70,
    },

    box_descricao: {
        width: 215,
        justifyContent: 'space-between',
        marginLeft: 15,
        marginTop: 8,
        marginBottom: 8,

        // backgroundColor: 'red',
    },

    descricao: {
        fontSize: 17,
        lineHeight: 15,
        color: '#000000',
    },

    flatItemInfo: {
        fontSize: 12,
        color: '#999',
        lineHeight: 24,
    },
    flatItemImg: {
        justifyContent: 'center',
    },
    flatItemImgIcon: {
        width: 26,
        height: 26,
        tintColor: '#B727FF',
    }

});

export default Consultas;