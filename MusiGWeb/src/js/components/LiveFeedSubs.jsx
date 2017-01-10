import React from 'react';

export default class LiveFeedSubs extends React.Component {
    render() {

        return (
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Add new subscriptions <br></br>
                        <small>Each new upload from channels you are following will be displayed in your LiveFeed </small></h1>
                    </div>
                </div>

                <div class="row">
                    {this.props.subscriptions.items.map(function(sub) {
                        return (
                        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-2 portfolio-item">
                            <a href="#">
                                <img class="img-responsive center-block img-circle" src={sub.snippet.thumbnails.high.url} alt={sub.snippet.title} />
                            </a>
                            <h4 class="text-center">{sub.snippet.title}</h4>
                            <div class="text-center">
                                <button class="btn btn-outlined btn-white btn-sm">Follow!</button>
                            </div>
                        </div>
                        )
                    })}
                </div>
            </div>
        );
    }
}
