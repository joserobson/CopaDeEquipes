import React, { Component } from 'react';
import { Grid } from 'react-bootstrap';
import { GridEquipeModel } from '../models/GridEquipeModel';
import { LinhaEquipeModel } from '../models/LinhaEquipeModel';
import { ColunaEquipeModel } from '../models/ColunaEquipeModel';
import { LinhaGridEquipe } from './LinhaGridEquipe';

export class GridEquipe extends Component {

    constructor(props) {

        super(props);       

        var equipes = props.equipes;

        var gridEquipes = this.criarGridDeEquipes(equipes);

        this.state = {
            gridEquipes: gridEquipes
        };

    }

    criarGridDeEquipes(equipes) {        

        const numero_maximo_colunas = 4;
        
        var grid = new GridEquipeModel([]);        
        let linha = new LinhaEquipeModel([]);

        for (var pos = 1; pos <= equipes.length; pos++) {            

            linha.Colunas.push(new ColunaEquipeModel(equipes[pos - 1]));

            if (pos % numero_maximo_colunas === 0) {

                if (pos > 0) {

                    grid.Linhas.push(linha);
                    linha = new LinhaEquipeModel([]);
                }
            }
        }

        if (linha.Colunas.length > 0) {
            grid.Linhas.push(linha);
        }

        console.log(grid);

        return grid;
    }


    render() {
        return (                
            <Grid fluid>
                {
                    this.state.gridEquipes.Linhas.map((linha,index) =>
                      (
                            <LinhaGridEquipe
                                key={index}
                                linha={linha}
                                handleSelecionarEquipe={this.props.handleSelecionarEquipe}
                                handleRemoverEquipe={this.props.handleRemoverEquipe}/>                            
                      )
                    )
                }                               
                </Grid>                        
        );
    }
}