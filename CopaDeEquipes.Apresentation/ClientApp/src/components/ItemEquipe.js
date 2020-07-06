import React, { Component } from 'react';
import './ItemEquipe.css';

export class ItemEquipe extends Component {

    constructor(props) {

        super(props);
        this.state = {
            equipe: props.equipe
        };

        this.handleSelecionarItem = this.handleSelecionarItem.bind(this);

    }

    handleSelecionarItem(event) {

        if (event.target.checked)
            this.props.handleSelecionarEquipe(this.state.equipe);
        else
            this.props.handleRemoverEquipe(this.state.equipe);
    }

    render() {
        return (
            <div id="itemEquipe">
                <table className='table table-bordered'>
                    <tbody>
                        <tr>
                            <td rowSpan='2' width='40%' style={{ verticalAlign: 'middle', textAlign: 'center' }}>
                                <input type="checkbox" className="custom-control-input" onChange={this.handleSelecionarItem} />
                            </td>
                            <td>
                                <label>{this.state.equipe.Nome}</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>{this.state.equipe.Sigla}</label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        );
    }
}