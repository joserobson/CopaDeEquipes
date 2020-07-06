import React, { Component } from 'react';
import { Row } from 'react-bootstrap';
import { ColunaGridEquipe } from './ColunaGridEquipe';

export class LinhaGridEquipe extends Component {

    constructor(props) {

        super(props);        
    }

    render() {
        return (
            <Row>
                {
                    this.props.linha.Colunas.map((coluna,index) =>
                        (
                            <ColunaGridEquipe
                                key={index}
                                coluna={coluna}
                                handleSelecionarEquipe={this.props.handleSelecionarEquipe}
                                handleRemoverEquipe={this.props.handleRemoverEquipe}
                            /> 
                     ))
                }
            </Row>
        );
    }
}