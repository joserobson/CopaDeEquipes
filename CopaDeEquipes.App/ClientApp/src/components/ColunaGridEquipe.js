import React, { Component } from 'react';
import { Col} from 'react-bootstrap';
import { ItemEquipe } from './ItemEquipe';

export class ColunaGridEquipe extends Component {

    constructor(props) {

        super(props);

        this.state = {            
        };

    }

    render() {
        return (            
            <Col sm={3}>
                <ItemEquipe
                    equipe={this.props.coluna.Equipe}
                    handleSelecionarEquipe={this.props.handleSelecionarEquipe}
                    handleRemoverEquipe={this.props.handleRemoverEquipe}
                />
            </Col>                            
        );
    }
}