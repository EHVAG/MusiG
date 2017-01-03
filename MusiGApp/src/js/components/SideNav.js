import React from 'react';

export default class Sidenav extends React.Component {
    render() {
        return (
            <div class="sidenav">
                <img src="../../img/EHVAGLogoWhiteResize.png" class="img-responsive"/>
                <a href="#" class="text-center">
                    <i class="fa fa-podcast fa-3x" aria-hidden="true"/>
                </a>
                <a href="#" class="text-center">
                    <i class="fa fa-reddit fa-3x" aria-hidden="true"/>
                </a>
                <a href="#" class="text-center">
                    <i class="fa fa-safari fa-3x" aria-hidden="true"/>
                </a>
                <a href="#" class="text-center">
                    <i class="fa fa-chrome fa-3x" aria-hidden="true"/>
                </a>
                <a href="#" class="text-center">
                    <i class="fa fa-chrome fa-3x" aria-hidden="true"/>
                </a>
                <a href="#" class="text-center bottom-left">
                    <i class="fa fa-user fa-3x" aria-hidden="true"/>
                </a>
            </div>
        );
    }
}
