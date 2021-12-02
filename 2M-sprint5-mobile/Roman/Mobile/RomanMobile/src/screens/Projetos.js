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

class Projetos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaProjetos: []
        };
    };

    // Define a função que faz a chamada pra api e traz os projetos 
    buscarProjetos = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');

            const resposta = await api.get('/projetos', {
                headers: {
                    Authorization: 'Bearer ' + token,
                },
            });
            if (resposta.status === 200) {
                console.warn('chegou')
                const dadosDaApi = resposta.data;
                this.setState({ listaProjetos: dadosDaApi });
                console.warn(this.state.listaProjetos)
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


            <View style={styles.bodyProjeto}>
                {/* Cabeçalho - Header */}
                <View style={styles.container_logo}>
                    <Image
                        source={require('../assets/coruja.png')}
                        style={styles.corujaLogo}
                    />
                </View>

                <View style={styles.mainHeader}>

                <View style={styles.pagTitulo}>
                            <Text style={styles.titulo}>Projetos</Text>
                        </View>


                </View>

                {/* Corpo - Body */}
                <View style={styles.mainBody}>
                    <FlatList
                        // contentContainerStyle={styles.mainBodyContent}
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.listaProjetos}
                        keyExtractor={item => item.idProjeto}
                        renderItem={this.renderItem}
                    />
                </View>
            </View>
        )
    };

    renderItem = ({ item }) => (
        <View style={styles.cardProjeto}>
            <View style={styles.flatItemRow}>
                <View style={styles.flatItemContainer}>
                    <Text style={styles.flatItemTitle}>{(item.nomeProjeto)}</Text>
                    <View style={styles.containerCard}>
                        <View style={styles.box_descricao}>
                            <Text style={styles.descricao}>{item.descricaoProjeto}</Text>
                        </View>
                        <View style={styles.boxLapis}>
                            <Image
                                source={require('../assets/pencil-ruler-solid.png')}
                                style={styles.lapis}
                            />
                            <Text style={styles.tema}>{item.idTemaNavigation.nomeTema}</Text>
                        </View>

                    </View>

                </View>
            </View>
        </View>
    )
};

const styles = StyleSheet.create({

    pagTitulo: {
        width: '40%',
        borderBottomColor: "#009DF5",
        borderBottomWidth: 1,
        alignItems: 'center'
    },

    titulo: {
        textTransform: 'uppercase',
        color: '#009DF5',
        fontWeight: 'bold',
        fontFamily: "Bebas Neue",
        fontSize: 26
    },

    container_logo: {
        justifyContent: 'center',
    },

    corujaLogo: {
        width: 150,
        height: 150,
    },

    bodyProjeto: {
        height: '100%',
        backgroundColor: 'rgba(255, 222, 50, 0.34)',
        alignItems: 'center'
    },

    mainBody: {
        flex: 4,
    },

    cardProjeto: {
        width: 390,
        borderRadius: 20,
        marginTop: 20,
        marginBottom:20,
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
    },

    tema:{
        marginTop: 15,
        fontSize: 26,
        lineHeight: 23,
        color: '#FFFFFF',
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
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
    mainHeaderRow: {
        flexDirection: 'row',
    },

    // conteúdo do body
    mainBody: {
        flex: 4,
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
        color: '#FFFFFF',
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
        color: '#FFFFFF',
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

export default Projetos;