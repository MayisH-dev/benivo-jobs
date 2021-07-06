import { useState } from 'react'
import { Modal } from 'antd'

const JobModal = ({ visible, id, toggleOff }) => {
  const [state, setState] = useState({ visible: false })
  return (
    <>
      <Modal
        onCancel={() => toggleOff(id)}
        onOk={() => toggleOff(id)}
        visible={visible}
        title={`Title${id}`}
      >
        <p>Some contents...</p>
        <p>Some contents...</p>
        <p>Some contents...</p>
        <p>Some contents...</p>
        <p>Some contents...</p>
      </Modal>
    </>
  )
}

export default JobModal
