import React, { Component } from 'react';
import { CopaHeader } from './CopaHeader';
import { EquipeModel } from '../models/EquipeModel';
import { SelecionaEquipes } from './SelecionaEquipes';
import { ResultadoCopa } from './ResultadoCopa';
import './Home.css';
import { CopaService } from '../services/CopaService';

export class Home extends Component {
    displayName = Home.name

    constructor(props) {

        super(props);        

        this.state = {
            header: {
                titulo: "Fase de Seleção",
                subTitulo: 'Selecione 8 equipes que você deseja para a competição e depois pressione o botão GERAR COPA para prosseguir'
            },
            equipes: [],
            showResultadoFinal: false,
            loading:false
        };        

        this.handleClickGerarCopa = this.handleClickGerarCopa.bind(this);
        this.handleIniciarNovaCopa = this.handleIniciarNovaCopa.bind(this);
    }

    async componentDidMount() {                    

        const resp = await CopaService.obterEquipes();
        if (resp.ok) {
            const data = await resp.json();

            var equipes = data.map((e) => {
                return new EquipeModel(e.id, e.nome, e.sigla, e.gols);
            });

            this.setState({
                equipes: equipes,
                loading: true
            });
            
        } else {

            const erro = await resp.json();
            alert(erro.message);
            console.error(erro);
        }
    }


    async handleClickGerarCopa(equipesSelecionadas) {

        if (equipesSelecionadas.size !== 8) {
            alert('Copa Inválida, são necessárias oito equipes para iniciar a copa.');
            return;
        }


        const resp = await CopaService.GerarCopa(equipesSelecionadas);        

        if (resp.ok) {

            var data = await resp.json();

            let header = this.state.header;
            header.subTitulo = 'Veja o Resultado';
            header.titulo = 'Resultado Final';

            let resultadoFinal = {
                campeao: data.campeao,
                viceCampeao: data.viceCampeao
            };

            this.setState({
                header: header,
                showResultadoFinal: true,
                resultadoFinal: resultadoFinal
            });
        } else {
                        
            var erro = await resp.json();
            console.error(resp);
            alert(erro.message);            
        }
    }

    handleIniciarNovaCopa() {

        this.setState({
            header: {
                titulo: "Fase de Seleção",
                subTitulo: 'Selecione 8 equipes que você deseja para a competição e depois pressione o botão GERAR COPA para prosseguir'
            },
            equipes: this.state.equipes,
            showResultadoFinal: false
        });
    }    


    render() {        

        return (
            <div className='container'>
                <CopaHeader
                    titulo={this.state.header.titulo}
                    subTitulo={this.state.header.subTitulo}
                />

                {
                    this.state.loading ?

                        <div id="bodyCopa" className='row'>
                            {this.state.showResultadoFinal
                                ?
                                <ResultadoCopa
                                    resultadoFinal={this.state.resultadoFinal}
                                    handleIniciarNovaCopa={this.handleIniciarNovaCopa}
                                />
                                :
                                <SelecionaEquipes
                                    equipes={this.state.equipes}
                                    handleClickGerarCopa={this.handleClickGerarCopa}
                                />
                            }
                        </div>
                        :
                        <p><em>Buscando Equipes...</em></p>
                }
            </div>
        );
    }
}
