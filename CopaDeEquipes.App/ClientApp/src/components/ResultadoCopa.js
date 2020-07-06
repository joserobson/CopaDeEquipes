import React, { Component } from 'react';
import './ResultadoCopa.css';

export class ResultadoCopa extends Component {

    constructor(props) {

        super(props);
        this.state = {
            campeao: props.resultadoFinal.campeao,
            viceCampeao: props.resultadoFinal.viceCampeao
        };

        this.handleIniciarNovaCopa = this.handleIniciarNovaCopa.bind(this);

    }        

    handleIniciarNovaCopa() {
        this.props.handleIniciarNovaCopa();
    }

    render() {
        return (
            <div id="resultadoCopa">
                <table className='table table-bordered'>
                    <tbody>
                        <tr>
                            <td width='10%'>
                                <div align='center'>
                                    <h3>1º</h3>
                                </div>                                
                            </td>
                            <td>
                                <h3>{this.state.campeao}</h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div align='center'>
                                    <h3>2º</h3>
                                </div>
                            </td>
                            <td>
                                <h3>{this.state.viceCampeao}</h3>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div className='row'>
                    <div className='col-sm-12 text-right'>
                        <button type='button' className='btn btn-default' onClick={this.handleIniciarNovaCopa}> Iniciar Nova Copa</button>
                    </div>
                </div>
            </div>
        );
    }


}