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
    buscarConsultas = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');

            const resposta = await api.get('/consultas/minhasMobile', {
                headers: {
                    Authorization: 'Bearer ' + token,
                },
            });
            if (resposta.status === 200) {
                const dadosDaApi = resposta.data;
                this.setState({ listaConsultas: dadosDaApi });
            }
        } catch (error) {
            console.warn(error);
        }
    };


    componentDidMount() {
        this.buscarConsultas();
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
                    <Text style={styles.flatItemTitle}>Nome do Paciente:<Text style={styles.valores}> {(item.idPacienteNavigation.nome)}</Text></Text>
                    <Text style={styles.flatItemTitle}>Data: <Text style={styles.valores}>{Intl.DateTimeFormat("pt-BR", {
                                year: 'numeric', month: 'numeric', day: 'numeric',
                                hour: 'numeric', minute: 'numeric',
                                hour12: true                                                
                            }).format(new Date(item.dataHora))}</Text>
        </Text>
                    <Text style={styles.flatItemTitle}>Especialidade: <Text style={styles.valores}>{(item.idMedicoNavigation.idEspecialidadeNavigation.especialidades)}</Text></Text>
                    <Text style={styles.flatItemTitle}>Situação: <Text style={styles.valores}>{(item.idSituacaoNavigation.situacao1)}</Text></Text>
                    <Text style={styles.flatItemTitle}>Clínica: <Text style={styles.valores}>{(item.idMedicoNavigation.idClinicaNavigation.nomeClinica)}</Text></Text>
                    <View style={styles.box_descricao}>
                    <Text style={styles.flatItemTitle}>Descrição: <Text style={styles.valores}>{(item.descricao)}</Text></Text>
                        </View>
                  
                
                </View>
            </View>
        </View>
    )
};

const styles = StyleSheet.create({


    cardConsulta: {
        width: 384,
        backgroundColor: '#FFFFFF',
        borderRadius: 10,
        marginBottom: 20,
    },

    valores:{
        fontFamily: 'TitilliumWeb-Light',
        fontStyle: 'normal',
        fontSize: 24,
        lineHeight: 35,
        color: '#0085FF',
    },

    // ------------------------------

    pagTitulo: {
        width: '40%',
        borderBottomColor: "#FFFFFF",
        borderBottomWidth: 3,
        alignItems: 'center',
    },

    titulo: {
        color: '#FFFFFF',
        fontFamily: "BebasNeue-Regular",
        fontSize: 40,
        marginBottom:2,
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
        marginTop: 20,
        marginBottom: 20,
        borderRadius: 20,
        backgroundColor: '#3DB0F0',
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
        paddingLeft: 14,
    },
    // dados do evento de cada item da lista (ou seja, cada linha da lista)
    flatItemRow: {
        flexDirection: 'row',
    },
    flatItemContainer: {
        flex: 1,
        padding:8
    },
    flatItemTitle: {     
        marginLeft: 15,
        marginRight:5,
        marginBottom:4,
        marginTop: 4,
        
        lineHeight: 35,
        fontFamily: 'TitilliumWeb-Light',
        fontStyle: 'normal',
        fontSize: 24,
        color: '#022A92',
    },

    box_descricao: {
        width: '100%',
        justifyContent: 'space-between',
    },

    descricao: {
        fontSize: 17,
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