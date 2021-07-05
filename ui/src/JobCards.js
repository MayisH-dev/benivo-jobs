import { Card, Col, Row } from 'antd'

const JobCards = ({ jobs }) => {
  console.log(jobs)
  if (jobs && jobs.length > 0)
    return (
      <div>
        <div className='site-card-wrapper'>
          <Row gutter={16}>
            {jobs.map(({ id, location, title, employmentTypeTitle }) => (
              <Col key={id} span={8}>
                <Card title={title} bordered={true}>
                  <strong>Type:</strong> {employmentTypeTitle}{' '}
                  <strong>Location:</strong> {location}
                </Card>
              </Col>
            ))}
          </Row>
        </div>
      </div>
    )
  else return <div>Nothin to display</div>
}

export default JobCards
