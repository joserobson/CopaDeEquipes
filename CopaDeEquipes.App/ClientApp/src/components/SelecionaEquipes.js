import React, { Component } from 'react';
import { GridEquipe } from './GridEquipe';
import './SelecionaEquipe.css';

export class SelecionaEquipes extends Component {

    constructor(props) {

        super(props);       

        this.handleSelecionarEquipe = this.handleSelecionarEquipe.bind(this);
        this.handleRemoverEquipe = this.handleRemoverEquipe.bind(this);
        this.handleCickGerarCopa = this.handleCickGerarCopa.bind(this);

        this.state = {
            equipes: props.equipes,
            equipesSelecionadas: new Set()            
        };
    }

    handleCickGerarCopa(event) {        
        this.props.handleClickGerarCopa(this.state.equipesSelecionadas);
    }

    handleSelecionarEquipe(equipe) {           
        const setEquipe = this.state.equipesSelecionadas;
        setEquipe.add(equipe);

        this.setState({
            equipesSelecionadas: setEquipe
        });

    }

    handleRemoverEquipe(equipe) {

        const setEquipe = this.state.equipesSelecionadas;

        if (setEquipe.has(equipe))
            setEquipe.delete(equipe);        

        this.setState({
            equipesSelecionadas: setEquipe
        });
    }


    render() {
        return (
            <div>
                <div className='row selecionados'>
                    <div className='col-sm-3'>
                        <h4>Selecionados {this.state.equipesSelecionadas.size} de 8 equipes</h4>
                    </div>
                    <div className='col-sm-9 text-right'>
                        <button type="button" className="btn btn-md" onClick={this.handleCickGerarCopa}>Gerar Copa</button>    
                    </div>
                </div>            

                <GridEquipe
                    equipes={this.state.equipes}
                    handleRemoverEquipe={this.handleRemoverEquipe}
                    handleSelecionarEquipe={this.handleSelecionarEquipe}
                /> 
            </div>
        );
    }
}