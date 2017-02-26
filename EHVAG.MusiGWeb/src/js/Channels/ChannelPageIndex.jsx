import React from 'react'
import FilterableChannelPage from './FilterableChannelPage'
import ChannelData from '../../data/ChannelData'

const ChannelPageIndex = React.createClass({
  render () {
    return (
      <FilterableChannelPage channels={ChannelData} />
    )
  }
})

export default ChannelPageIndex
