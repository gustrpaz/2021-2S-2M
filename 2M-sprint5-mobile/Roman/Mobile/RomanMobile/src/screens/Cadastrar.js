import React, { Component } from 'react';

import {
    FlatList,
    StyleSheet,
    Text,
    View,
    ScrollView,
    Image,
    TextInput,
    Button,
    TouchableOpacity,
} from 'react-native';

import api from '../services/api';
import { Picker } from '@react-native-picker/picker';
import AsyncStorage from '@react-native-async-storage/async-storage';

const InputMultiple = (props) => {
    return (
        <TextInput
            {...props} // Inherit any props passed to it; e.g., multiline, numberOfLines below
            editable
        />
    );
}

class Cadastro extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idTema: 0,
            nomeProjeto: '',
            descricaoProjeto: ''
        }
    }

    Cadastrar = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');

            const resposta = await api.post('/projetos',
                {
                    idTema: this.state.idTema,
                    nomeProjeto: this.state.nomeProjeto,
                    descricaoProjeto: this.state.descricaoProjeto
                },
                {
                    headers: {
                        Authorization: 'Bearer ' + token,
                    }
                });

            if (resposta.status == 201) {
                console.warn("Projeto cadastrado")
                this.setState({
                    idTema: 0,
                    nomeProjeto: '',
                    descricaoProjeto: ''
                })
            }
        } catch (error) {
            console.warn(error);
        }


    }

    render() {
        return (
            <View style={styles.pagina}>
                <ScrollView style={styles.ScrollView} >
                    <View style={styles.header}>
                        <Image
                            source={require('../assets/coruja.png')}
                            style={styles.corujaLogo}
                        />
                        <View style={styles.pagTitulo}>
                            <Text style={styles.titulo}>Cadastro</Text>
                        </View>
                    </View>
                    <View style={styles.main}>
                        <Picker
                            selectedValue={this.state.idTema}
                            onValueChange={(itemValue, itemIndex) => this.setState({ idTema: itemValue })}
                            style={styles.picker}>
                            <Picker.Item label="Selecione o tema" value="0" />
                            <Picker.Item label="Artes" value="1" />
                            <Picker.Item label="Biologia" value="2" />
                            <Picker.Item label="Matemática" value="3" />
                        </Picker>
                        <TextInput
                            style={styles.input}
                            onChangeText={nomeProjeto => this.setState({ nomeProjeto })}
                            value={this.state.nomeProjeto}
                            placeholder="Digite o titulo do projeto"
                            keyboardType="default"
                        />
                        <InputMultiple
                            multiline
                            numberOfLines={4}
                            onChangeText={descricaoProjeto => this.setState({ descricaoProjeto })}
                            value={this.state.descricaoProjeto}
                            style={styles.inputMultiple}
                            placeholder="Digite a descrição do projeto"
                        />
                        {/* <Button
                            title="Cadastro"
                            style={styles.btn}
                            width='75%'
                            color='#009DF5'
                            borderColor='#FFF'
                            backgroundColor='#FFF'
                            borderRadius='20'
                        /> */}
                        <TouchableOpacity
                            title="Cadastro"
                            style={styles.btn}
                            onPress={() => this.Cadastrar()}
                        >
                            <Text style={styles.btnText}>Cadastrar</Text>
                        </TouchableOpacity>
                    </View>
                </ScrollView>
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
    ScrollView: {
        width: '100%'
    },

    header: {
        alignItems: 'center'
    },

    // estilo dos ícones da tabBar
    corujaLogo: {
        flex: 1,
        width: 150,
        height: 150,
    },

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

    main: {
        flex: 2,
        marginTop: 40,
        width: '100%',
        alignItems: 'center'
    },

    picker: {
        width: '78%',
        borderRadius: 60,
        borderColor: "#009DF5",
        placeholderTextColor: '#A4A4A4',
        borderStyle: 'solid',
        borderWidth: 1,
        backgroundColor: '#FFF',
        placeholderTextColor: '#A4A4A4',
    },

    input: {
        width: '80%',
        borderRadius: 20,
        borderColor: "#009DF5",
        placeholderTextColor: '#A4A4A4',
        borderStyle: 'solid',
        borderWidth: 1,
        backgroundColor: '#FFF',
        marginTop: 10,
    },

    inputMultiple: {
        width: '80%',
        borderRadius: 20,
        borderColor: "#009DF5",
        placeholderTextColor: '#A4A4A4',
        borderStyle: 'solid',
        borderWidth: 1,
        backgroundColor: '#FFF',
        marginTop: 20,
    },
    btn: {
        width: '30%',
        borderColor: '#009DF5',
        borderWidth: 1,
        backgroundColor: '#FFF',
        borderRadius: 20,
        marginTop: 20,
        height: 36,
        alignItems: 'center',
        justifyContent: 'center'
    },

    btnText: {
        color: '#009DF5',
        fontWeight: 'bold',
        fontSize: 18
    }
});

export default Cadastro;
